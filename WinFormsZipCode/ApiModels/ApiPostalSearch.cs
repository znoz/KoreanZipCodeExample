using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinFormsZipCode.ApiModels
{
    /// <summary>
    /// 우편번호 검색 API 모델
    /// </summary>
    public class ApiPostalSearch : ApiModelBase
    {
        /// <summary>
        /// 요청
        /// </summary>
        public class Request : RequestBase
        {
            /// <summary>
            /// 페이지 당 출력 개수 최대값
            /// </summary>
            public const int MAX_PAGE_SIZE = 50;

            /// <summary>
            /// 검색어
            /// </summary>
            [JsonProperty("srchwrd")]
            public string? SearchKeyword { get; set; }

            /// <summary>
            /// 페이지당 출력될 개수를 지정(최대50)
            /// </summary>
            [JsonProperty("countPerPage")]
            [Range(1, MAX_PAGE_SIZE, ErrorMessage = "페이지당 최대 출력 개수를 초과 하였습니다.")]
            public int CountPerPage { get; set; } = DEFAULT_PAGE_SIZE;

            /// <summary>
            /// 출력될 페이지 번호
            /// </summary>
            [JsonProperty("currentPage")]
            public int CurrentPage { get; set; } = DEFAULT_PAGE;
        }

        /// <summary>
        /// 응답
        /// </summary>
        [XmlRoot("NewAddressListResponse")]
        public class Response
        {
            /// <summary>
            /// 공통 메시지 헤더
            /// </summary>
            [XmlElement("cmmMsgHeader")]
            public CmmMsgHeader? Header { get; set; }

            /// <summary>
            /// 주소 목록
            /// </summary>
            [XmlElement("newAddressListAreaCdSearchAll")]
            public List<Address>? AddressList { get; set; }

            /// <summary>
            /// 성공 여부
            /// </summary>
            public bool IsSuccess => Header?.SuccessYN == "Y";
        }

        /// <summary>
        /// 공통 메시지 헤더
        /// </summary>
        public class CmmMsgHeader
        {
            /// <summary>
            /// 요청 메시지 ID
            /// </summary>
            [XmlElement("requestMsgId")]
            public string? RequestMsgId { get; set; }

            /// <summary>
            /// 응답 메시지 ID
            /// </summary>
            [XmlElement("responseMsgId")]
            public string? ResponseMsgId { get; set; }

            /// <summary>
            /// 응답 시간
            /// </summary>
            [XmlElement("responseTime")]
            public string? ResponseTime { get; set; }

            /// <summary>
            /// 응답 시간
            /// </summary>
            public DateTime? ResponseDatetime 
                => DateTime.TryParseExact(ResponseTime, "yyyyMMdd:HHmmssfff", null, System.Globalization.DateTimeStyles.None, out var dt) ? dt : null;

            /// <summary>
            /// 성공 여부
            /// </summary>
            [XmlElement("successYN")]
            public string? SuccessYN { get; set; }

            /// <summary>
            /// 결과 코드
            /// </summary>
            [XmlElement("returnCode")]
            public string? ReturnCode { get; set; }

            /// <summary>
            /// 에러 메시지
            /// </summary>
            [XmlElement("errMsg")]
            public string? ErrMsg { get; set; }

            /// <summary>
            /// 전체 데이터 개수
            /// </summary>
            [XmlElement("totalCount")]
            public int TotalCount { get; set; }

            /// <summary>
            /// 페이지 당 출력 개수
            /// </summary>
            [XmlElement("countPerPage")]
            public int CountPerPage { get; set; }

            /// <summary>
            /// 전체 페이지 수
            /// </summary>
            [XmlElement("totalPage")]
            public int TotalPage { get; set; }

            /// <summary>
            /// 현재 페이지
            /// </summary>
            [XmlElement("currentPage")]
            public int CurrentPage { get; set; }
        }

        /// <summary>
        /// 주소 항목
        /// </summary>
        public class Address
        {
            /// <summary>
            /// 우편번호
            /// </summary>
            [XmlElement("zipNo")]
            public string? ZipNo { get; set; }

            /// <summary>
            /// 도로명 주소
            /// </summary>
            [XmlElement("lnmAdres")]
            public string? DoroAddress { get; set; }

            /// <summary>
            /// 지번 주소
            /// </summary>
            [XmlElement("rnAdres")]
            public string? JibunAddress { get; set; }
        }


    }
}
