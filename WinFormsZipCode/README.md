# WinForm 예제 소스 파일
파일 | 설명
-- | --
Program.cs | 어플리케이션이 시작하는 진입점
FormMain.cs | 예제 프로젝트의 메인 폼
app.config | 설정 파일
ApiModels/ApiModelBase.cs | 공공DB API 모델의 베이스 클래스 (공통 부분을 모아둠)
ApiModels/ApiPostalSearch.cs | 우편번호 조회 API 모델

- API 모델 클래스는 하위에 Request, Response 클래스를 포함한다.
  - Request: API 호출 할 때의 파라미터 정의
  - Response: API 응답 받을 때의 XML 필드 정의

# app.config
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="ServiceKey" value="" />
    <add key="ApiUrl" value="http://openapi.epost.go.kr/postal/retrieveNewAdressAreaCdSearchAllService/retrieveNewAdressAreaCdSearchAllService/getNewAddressListAreaCdSearchAll" />
  </appSettings>
</configuration>
```
- ServiceKey: 공공 API에서 발급 받은 서비스 키
- ApiUrl: 공공데이터포털의 우편번호 조회 API 주소
