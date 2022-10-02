namespace Stonksy.Core.Types;

public readonly record struct Symbol(string Value);

public record Company(Symbol Symbol);