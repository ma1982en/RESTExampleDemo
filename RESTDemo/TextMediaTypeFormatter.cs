

using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
 

namespace RESTDemo;

public class TextMediaTypeFormatter : TextInputFormatter
{
    public TextMediaTypeFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/plain"));
        SupportedEncodings.Add(Encoding.UTF8);
    }

    public override bool CanRead(InputFormatterContext context)
    {
        return true;
    }

    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
    {
        var resultText = "";
        var taskCompletionSource = new TaskCompletionSource<object>();
        
        try
        {
            var requestStream = context.HttpContext.Request.BodyReader.AsStream();

            var memory = new MemoryStream();
            await requestStream.CopyToAsync(memory);
            resultText= System.Text.Encoding.UTF8.GetString(memory.ToArray());
            taskCompletionSource.SetResult(resultText);
            
        }
        catch (Exception e)
        {
            taskCompletionSource.SetException(e);
        }

        return await InputFormatterResult.SuccessAsync(resultText);
    }
}