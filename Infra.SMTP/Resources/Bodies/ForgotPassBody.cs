using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Infra.SMTP.Resources.Bodies
{
    public static class ForgotPassBody
    {
        public static string ForgetBody(string code)
        {
            string imagePath = @"xxxxxxxx.jpg";
            LinkedResource img = new LinkedResource(imagePath, MediaTypeNames.Image.Jpeg)
            {
                ContentId = "MyImage"
            };
            string body =
                 @$"<html>
                    <body>
                    <h1>{code}</h1>  
                   <br>
                </tr>  
                <tr>  
                    <td>  
                      <img src=cid:MyImage  id='img' alt='' width='200px' height='200px'/>   
                    </td>  
                </tr></table>  
            ";
            return body;
        }
    }
}
