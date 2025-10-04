using static InsureYouAI.Controllers.ArticleController;

namespace InsureYouAI.DTOs.OpenAI;

public class OpenAIResponse
{
    public List<Choice> choices { get; set; }
}
