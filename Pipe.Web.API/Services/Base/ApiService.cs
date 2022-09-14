using System.Text;
using Domain.Dto.Base;
using Newtonsoft.Json;

namespace Pipe.Web.API.Services.Base;

public abstract class ApiService<TDto> : IApiService<TDto>
    where TDto : BaseEntityDto, new()
{
    private readonly string? _clientName;
    protected IHttpClientFactory HttpClientFactory { get; set; }
    protected string BaseUrl { get; set; }

    protected ApiService(IHttpClientFactory httpClientFactory, string baseUrl, string? clientName)
    {
        _clientName = clientName;
        HttpClientFactory = httpClientFactory;
        BaseUrl = baseUrl;
    }

    public async Task<IEnumerable<TDto>> GetAllAsync(CancellationToken ct) => await SendRequestAsync<IEnumerable<TDto>>(HttpMethod.Get, BaseUrl, null, ct);

    public async Task<TDto> GetByIdAsync(Guid id, CancellationToken ct) => await SendRequestAsync<TDto>(HttpMethod.Get, $"{BaseUrl}/{id}", null, ct);

    public async Task<TDto> UpsertAsync(TDto dto, CancellationToken ct)
    {
        var method = HttpMethod.Post;
        var url = BaseUrl;

        if (dto.Id != null && dto.Id != Guid.Empty)
        {
            method = HttpMethod.Put;
            url =  $"{BaseUrl}/{dto.Id}";
        }

        return await SendRequestAsync<TDto>(method, url, dto, ct);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
    {
        var url = $"{BaseUrl}/{id}";
        return await SendRequestAsync<bool>(HttpMethod.Delete, url, null, ct);
    }

    public async Task<T> SendRequestAsync<T>(HttpMethod method, string url, Object? data, CancellationToken ct)
    {
        try
        {
            var client = string.IsNullOrEmpty(_clientName) ? HttpClientFactory.CreateClient() : HttpClientFactory.CreateClient(_clientName);
            var message = new HttpRequestMessage(method, url);
            message.Headers.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Clear();
            if (data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            }

            var response = await client.SendAsync(message, ct);
            var content = await response.Content.ReadAsStringAsync(ct);
            
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(content, null, response.StatusCode);
            }
            
            var responseDto = JsonConvert.DeserializeObject<T>(content);
            return responseDto;
        }
        catch (Exception ex)
        {
            // ignored
            throw new BadHttpRequestException(ex.Message);
        }
    }
}