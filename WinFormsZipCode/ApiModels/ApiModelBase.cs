using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsZipCode.ApiModels
{
    /// <summary>
    /// API 모델 베이스
    /// </summary>
    public class ApiModelBase
    {
        /// <summary>
        /// 디폴트 페이지 출력 개수
        /// </summary>
        public const int DEFAULT_PAGE_SIZE = 10;

        /// <summary>
        /// 디폴트 페이지
        /// </summary>
        public const int DEFAULT_PAGE = 1;

        /// <summary>
        /// API URL 저장용
        /// </summary>
        private static string? _ApiUrl;

        /// <summary>
        /// APU URL
        /// </summary>
        protected static string? ApiUrl
        {
            get
            {
                _ApiUrl ??= ConfigurationManager.AppSettings["ApiUrl"];
                return _ApiUrl;
            }
        }

        /// <summary>
        /// 요청 베이스
        /// </summary>
        public class RequestBase
        {
            /// <summary>
            /// 공공 API 서비스 키 저장용
            /// </summary>
            private string? _ServiceKey;

            /// <summary>
            /// 공공 API 서비스 키
            /// </summary>
            public string? ServiceKey
            {
                get
                {
                    _ServiceKey ??= ConfigurationManager.AppSettings["ServiceKey"];
                    return _ServiceKey;
                }
            }

            /// <summary>
            /// 클래스의 프로퍼티를 문자열 파라미터로 변환
            /// </summary>
            /// <returns></returns>
            public string ToQueryParams()
            {
                var properties = GetType().GetProperties()
                    .Where(p => p.GetValue(this, null) != null)
                    .Select(p =>
                    {
                        var attribute = p.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault() as JsonPropertyAttribute;
                        var key = attribute != null ? attribute.PropertyName : p.Name;
                        return $"{key}={p.GetValue(this, null)?.ToString() ?? string.Empty}";
                    });

                return string.Join("&", properties);
            }

            /// <summary>
            /// API URL 생성
            /// </summary>
            /// <returns></returns>
            public string GetApiUrl()
            {
                return ApiUrl + "?" + ToQueryParams();
            }
        }
    }
}
