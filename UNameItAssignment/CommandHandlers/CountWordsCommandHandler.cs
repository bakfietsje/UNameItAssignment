using System.Text.RegularExpressions;
using MediatR;
using UNameItAssignment.Commands;
using UNameItAssignment.DTOs;

namespace UNameItAssignment.CommandHandlers;

public class CountWordsCommandHandler : IRequestHandler<CountWordsCommand, IEnumerable<WordCountDto>>
{
    public Task<IEnumerable<WordCountDto>> Handle(CountWordsCommand request, CancellationToken cancellationToken)
    {
        var words = GetWordsCount(request.Text);
        var result = words.Select(x => new WordCountDto(x.Key, x.Value));
        
        return Task.FromResult(result);
    }
    
    private static IEnumerable<KeyValuePair<string, int>> GetWordsCount(string text)
    {
        var cleanedText = Regex.Replace(text, @"[^\w\s]", "");
        var words = cleanedText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var wordsWithCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (var word in words)
        {
            if (wordsWithCount.TryGetValue(word, out var value))
            {
                wordsWithCount[word] = value + 1;
            }
            else
            {
                wordsWithCount.Add(word, 1);
            }
        }

        return wordsWithCount.OrderByDescending(x => x.Value);
    }
}