﻿using System.Net.Http.Headers;

namespace API.Tests.Utility;

[TestClass]
public abstract class TestBase
{
    private const string _customerToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6Imluc18yVzVYN2tEMUJiR2RJRGRQR0tJSFNETTBjZnAiLCJ0eXAiOiJKV1QifQ.eyJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUxNzMvIiwiYXpwIjoiaHR0cHM6Ly9zdGlycmluZy1tdXNrb3gtMy5hY2NvdW50cy5kZXYiLCJleHAiOjIwMTMzMjQzMDcsImlhdCI6MTY5Nzk2NDMwOCwiaXNzIjoiaHR0cHM6Ly9zdGlycmluZy1tdXNrb3gtMy5jbGVyay5hY2NvdW50cy5kZXYiLCJqdGkiOiJjYTg0N2NjZmI4ZDAxZTk1OGZkZCIsIm5iZiI6MTY5Nzk2NDMwMywicm9sZSI6ImN1c3RvbWVyIiwic3ViIjoidXNlcl8yV25VUlV4UGh1S2xQZmlKUVlDYm8wVHZSQnEifQ.0UUvlSp2-ix6vsHxUhDxgbi0d4Y31ZQxi3DpfGintwRrGbxMNjw0qVDGA0wvn7VjyExDCvgghU3QgOo3-extJpbQ0aTp4otGf27nNDLbnxqe-w7iyhCu1XRWarwsrey_ll9u6V4bmIRdofhgO-fjsn1SZEksFajc2h1tgVAHua0VAFChAWj_2PxBJnqLBV-XYT3btn_B5FREs3VvS-Jc5pj7blthrqFYHQrYa3SHl66G4I4cpLSaifsyOT1fG2H9-uDY62uyl0QFiP6Ne-nhtUwtZJtHeAGc31c-FrdlOBZsUa2G7EG6oKl3TJ0_zSeliJmuytYzfF821MPADLnV2g";
    private const string _employeeToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6Imluc18yVzVYN2tEMUJiR2RJRGRQR0tJSFNETTBjZnAiLCJ0eXAiOiJKV1QifQ.eyJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUxNzMvIiwiYXpwIjoiaHR0cHM6Ly9zdGlycmluZy1tdXNrb3gtMy5hY2NvdW50cy5kZXYiLCJleHAiOjIwMTMzMjQyODEsImlhdCI6MTY5Nzk2NDI4MiwiaXNzIjoiaHR0cHM6Ly9zdGlycmluZy1tdXNrb3gtMy5jbGVyay5hY2NvdW50cy5kZXYiLCJqdGkiOiJjM2VlZjM4ZmQ1MDFkOTQ4ODczNiIsIm5iZiI6MTY5Nzk2NDI3Nywicm9sZSI6ImVtcGxveWVlIiwic3ViIjoidXNlcl8yV25VUUY0NHNiUEVCZmZacGlSWmd6TTVPYkwifQ.y5MQ9K86ZwZ-AzI67uC8VbRSzrHMq527J5qbeS86aSLJ8I4M7SEBCehhwcexivv82lCQ04d2jHPeibJ1i1fFiHB6QA4TqERq-q9ZD6WEC4OmaPzwzTWqSl8_QOk3L1n60Z1j7DIXTM-Qi2oaBteb0DhlFz0xkKkmW59lwPCR19yU8gw6YFxW04Wr6wXoDHE2MYSoIE1Rulhi9AIS9q9DX4N3zuWXYIoQhLmo-7ucvSrWCHCd-k-Tshr6ztE-OHyHRGiKdRQAd2JC2IQfWtb2zZBrjAFayaOUioPVQcCkcE9OHK6ngFCoHyEG3eVTVKnmBnbI5bmAoSPw7VLQtgR6Ew";
    private const string _adminToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6Imluc18yVzVYN2tEMUJiR2RJRGRQR0tJSFNETTBjZnAiLCJ0eXAiOiJKV1QifQ.eyJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUxNzMvIiwiYXpwIjoiaHR0cHM6Ly9zdGlycmluZy1tdXNrb3gtMy5hY2NvdW50cy5kZXYiLCJleHAiOjIwMTMzMjQyNDcsImlhdCI6MTY5Nzk2NDI0OCwiaXNzIjoiaHR0cHM6Ly9zdGlycmluZy1tdXNrb3gtMy5jbGVyay5hY2NvdW50cy5kZXYiLCJqdGkiOiIzNjc3ZDljMjMxMjNkYmM1MGVhYyIsIm5iZiI6MTY5Nzk2NDI0Mywicm9sZSI6ImFkbWluIiwic3ViIjoidXNlcl8yV25VT1VDbXRuTXduWlFwd3ZCTG5CbkM2dGMifQ.PNz-Ea-IYwnx9aSFcezAFRsgdQQfkLAWj7fgt5G1ktXWYgaET4W7fP0z_RfN8jIoXYHpxBVjTZx8NLYIEyfNZzZCXt1rDi9njmVO7zmQcLKu1WkFxAVhIpKMKlOWJF1w4dfs7NDiSVZULYwbZro9m_xpPW1X9j-VZgbRrd4ejEYaqlGA_U0Q7i3P34nqNBeIgYCa8KcpcUWuiVQ13U7l6guazWBi9u_PEj6GERNl3JkfujmBRZkRjrkJ2jJcbMuG63cI16AmWh0nT5V3zzGIjiHUuSDlsyFoa9a6vjU-imsav4QS1aRRj-L4Pj_aqM8kCBCGaP5UTCQMPBLZJpDtVw";
    protected WebApiFactory<Program> _factory;
    protected IServiceProvider _provider;

    [TestInitialize]
    public void Initialize()
    {
        _provider = Startup.ConfigureServices();
        _factory = _provider.GetRequiredService<WebApiFactory<Program>>();
    }

    public virtual async Task Endpoints_EnsureAuthorization(string method,
                                                string endpoint,
                                                string? role = null,
                                                bool isAuthorized = false)
    {
        var client = role switch
        {
            Roles.ADMIN => CreateAdminClient(),
            Roles.EMPLOYEE => CreateEmployeeClient(),
            Roles.CUSTOMER => CreateCustomerClient(),
            _ => CreateClient(),
        };
        var httpMethod = method switch
        {
            "Get" => HttpMethod.Get,
            "Post" => HttpMethod.Post,
            "Put" => HttpMethod.Put,
            "Delete" => HttpMethod.Delete,
            _ => throw new ArgumentException("Invalid HTTP method", nameof(method)),
        };

        var result = await client.SendAsync(new HttpRequestMessage(httpMethod, endpoint));

        if (isAuthorized)
            Assert.IsTrue(result.StatusCode is not HttpStatusCode.Forbidden and not HttpStatusCode.Unauthorized);
        else
            Assert.IsTrue(result.StatusCode is HttpStatusCode.Forbidden or HttpStatusCode.Unauthorized);
    }

    protected HttpClient CreateClient(string? token = null)
    {
        var client = _factory.CreateClient();
        if (!string.IsNullOrEmpty(token))
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return client;
    }

    protected HttpClient CreateAdminClient() => CreateClient(_adminToken);
    protected HttpClient CreateEmployeeClient() => CreateClient(_employeeToken);
    protected HttpClient CreateCustomerClient() => CreateClient(_customerToken);
}
