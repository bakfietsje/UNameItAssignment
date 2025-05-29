using MediatR;
using UNameItAssignment.DTOs;

namespace UNameItAssignment.Commands;

public record CountWordsCommand(string Text, CancellationToken CancellationToken) : IRequest<IEnumerable<WordCountDto>>;