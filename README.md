# 공공 API 우편번호 조회 예제 - .NET WinForm
[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue.svg?logo=VisualStudio)](https://visualstudio.microsoft.com/ko/)
[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-blue.svg?logo=.NET)](https://learn.microsoft.com/ko-kr/dotnet/core/whats-new/dotnet-8/overview)
[![공공데이터포털 우편번호 정보조회](https://img.shields.io/badge/공공데이터포털-우편번호%20정보조회-blue.svg)](https://www.data.go.kr/data/15056971/openapi.do)
[![Newtonsoft.Json](https://img.shields.io/badge/Newtonsoft.Json-13.0-blue.svg)](https://www.newtonsoft.com/json)

# 추가 패키지
- System.Configuration.ConfigurationManager : app.config 설정 파일 제어용
- Newtonsoft.Json : API Model 클래스의 프로퍼티 매핑용

# API 설정 방법
1. [공공데이터포털](https://www.data.go.kr/)에 가입한다.
1. [우편번호 정보조회](https://www.data.go.kr/data/15056971/openapi.do) API 페이지에서 활용신청을 한다.
1. [인증키 발급현황](https://www.data.go.kr/iim/api/selectApiKeyList.do) 메뉴로 이동하여 일반 인증키를 복사한다.
1. 프로젝트에서 app.config 파일을 열고 ServiceKey 항목의 값에 위에서 복사한 인증키를 붙여 넣는다.
