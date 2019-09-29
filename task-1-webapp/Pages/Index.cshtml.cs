using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace task_1_webapp.Pages
{



    
    public class IndexModel : PageModel
    {
    

        private static readonly HttpClient client = new HttpClient();

        
        public ActionResult OnPostAsync(string submit,string email)
        {

               string callbackUrl =  Environment.GetEnvironmentVariable("callbackUrl");
                
                
                var payload = new Dictionary<string, string>
                    {
                    {"message", submit.ToLower()}
                    };
                    string json = JsonConvert.SerializeObject(payload, Formatting.Indented);
                    var httpContent = new StringContent(json.ToString(), Encoding.UTF8, "application/json");    
                    



            switch(submit)
            {
                case "Good":
                client.PostAsync(callbackUrl, httpContent);
                break;
                case "Bad":
                client.PostAsync(callbackUrl, httpContent);
                break;
            }
        return RedirectToPage("Index");
        }
    }   
}



