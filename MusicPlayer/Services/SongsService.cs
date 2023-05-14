using System;
using System.Text;
using MusicPlayer.Constants;
using MusicPlayer.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MusicPlayer.Services
{
    public interface ISongsService
    {
        Task<IEnumerable<Song>> GetSongs(CancellationToken cancellationToken = default);
    }

    public class SongsService : BaseApiService, ISongsService
    {
        public SongsService(IHttpClientProvider httpClientProvider)
        {
            Initialize(httpClientProvider);
        }

        /// <summary>
        /// Get the songs list from cloud
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<Song>> GetSongs(CancellationToken cancellationToken = default)
        {
            try
            {
                var request = CreateHttpGetRequestMessageAsync();
                var urlBuilder = new StringBuilder();
                urlBuilder.Append(ApiUrls.BaseAddress != null ? ApiUrls.BaseAddress.TrimEnd('/') : "").Append(ApiUrls.SongsUrl);

                request.RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute);
                var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    var songsCollection = JsonSerializer.Deserialize<SongsCollection>(responseData, options);
                    return songsCollection.Songs;
                }
                else
                {
                    throw new Exception("Fatal Error Occured while retrieving songs data");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Fatal Error Occured while retrieving songs data", innerException: exception);
            }
        }
    }
}

