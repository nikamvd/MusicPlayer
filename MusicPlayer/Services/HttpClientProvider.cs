using System;
namespace MusicPlayer.Services
{
    public class HttpClientProvider : IHttpClientProvider
    {
        private HttpClient _current;

        public HttpClient Client
        {
            get
            {
                if (_current != null)
                {
                    return _current;
                }

                var handler = new HttpClientHandler();
                _current = new HttpClient(handler);
                return _current;
            }
        }
    }
}

