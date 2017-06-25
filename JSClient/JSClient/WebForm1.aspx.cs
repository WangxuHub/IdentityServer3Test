using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var jsonStr = @"
                {
                  ""id_token"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImZYN2syZy1oNXBVbGlWZEJlajltemYtNTBFbyIsImtpZCI6ImZYN2syZy1oNXBVbGlWZEJlajltemYtNTBFbyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjY3NzkiLCJhdWQiOiJqcyIsImV4cCI6MTQ5ODM4NzE5OSwibmJmIjoxNDk4Mzg2ODk5LCJub25jZSI6IjlkNWNjMmNmZGE0YzQyZjRhYTk3Y2Q5NjhmMmE4NTdjIiwiaWF0IjoxNDk4Mzg2ODk5LCJhdF9oYXNoIjoiSW1SUGFmNW02OE43TGtIZlJjUGc5ZyIsInNpZCI6IjdhNmU0OWYzMmVkNWIyYzJjMGY2YTczMTllOTY1MzBjIiwic3ViIjoiMSIsImF1dGhfdGltZSI6MTQ5ODM4Mzc0OSwiaWRwIjoiaWRzcnYiLCJhbXIiOlsicGFzc3dvcmQiXX0.L_UUH-s82RrSPZq8pAMs_r_yZyBERTzEPUoQF-gy13aYOVunhxPrm-0Em5zObWLTB8oeyhK7bSJKt-K9Ar-WKE30XtYp6LRGN6iKC2XdRsSwlZyPNxBwJKQVpj4gurEjFdVIeAZdLQA6aBe5G71sV-J0yxyPcABb992NBTpyJkHa4-SGv3eatQuH5s0quQPNbpbDaMZCVJWq1NB0TRC3yXUYxRRutQXVCcCQPaiCcp_rsRdAD2RYkI_7cIRf2mzjjlbVSqG-NurBQA-csnK40qHj14UrrDh8_XOOCfmWosFvo8v0IT_4Mif68eZtD-Ois-tMXyHB8SY2aYKNdLV5KA"",
                  ""session_state"": ""0i9vzT9vDvy1vFmgQjmTp4BpDD5f7WJLZueLem2UTV0.dcdae90d997f20b36d72b3482b6a4b99"",
                  ""access_token"": ""eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImZYN2syZy1oNXBVbGlWZEJlajltemYtNTBFbyIsImtpZCI6ImZYN2syZy1oNXBVbGlWZEJlajltemYtNTBFbyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjY3NzkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjY3NzkvcmVzb3VyY2VzIiwiZXhwIjoxNDk4MzkwNDk5LCJuYmYiOjE0OTgzODY4OTksImNsaWVudF9pZCI6ImpzIiwic2NvcGUiOlsib3BlbmlkIiwicHJvZmlsZSIsImVtYWlsIiwiYXBpIl0sInN1YiI6IjEiLCJhdXRoX3RpbWUiOjE0OTgzODM3NDksImlkcCI6Imlkc3J2IiwiYW1yIjpbInBhc3N3b3JkIl19.CdFdun-wMDRJK4TOkTGquODjIIZ3CJq7FazLwOEDRHFf_qCavP0LJX_aT6RozVnjPGjMeKA-E-BSNpcieWYyuk7EO5BKJVHlgZILZxR7FU8AQzn8fNWUr6KyIZmGCYm5pCizHHfCMLNDHRhg9SPBdCW_k1V55oMuw-iQ-CZutq5a0rbNXTP1OGPBnJfOgxf4VMZOkPLmvcfB6qJXZxfKgE7YUPmE7CY7dfEQhUzQZhRmivBndQxnZbGQZJuSrXa3PfgRAXEn7UrYXd68CSgL40RBB4Gk17nV59CuzPClxeqScq773h7PsxSUBUTbQAi5aeGCdaNtVixOJobn2DkNUQ"",
                  ""token_type"": ""Bearer"",
                  ""scope"": ""openid profile email api"",
                  ""profile"": {
                                ""sid"": ""7a6e49f32ed5b2c2c0f6a7319e96530c"",
                    ""sub"": ""1"",
                    ""auth_time"": 1498383749,
                    ""idp"": ""idsrv"",
                    ""amr"": [
                      ""password""
                    ],
                    ""given_name"": ""Bob"",
                    ""family_name"": ""Smith"",
                    ""email"": ""bob.smith@email.com""
                  },
                  ""expires_at"": 1498390499
                }";

            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<token>(jsonStr);

            var accessToken = obj.access_token;

            var strArr = accessToken.Split('.');
            var str1 = strArr[0];
            var str2 = strArr[1];
            var str3 = strArr[2];


            var s1 = ConventBase64ToString(str1);
            var s2 = ConventBase64ToString(str2);
            var s3 = ConventBase64ToString(str3);
        }

        public string ConventBase64ToString(string base64String)
        {
            var bytes = Convert.FromBase64String(base64String);

            var str = System.Text.Encoding.UTF8.GetString(bytes);
            return str;
        }
    }

    public class token {
        public string id_token;
        public string session_state;
        public string access_token;
        public string token_type;
        public string scope;
        public int expires_at;
    }
}