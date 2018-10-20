/// NuGet packages:
///
/// Odepax.Obganism.Lexing.Definitions
/// Odepax.Obganism.Lexing
/// Odepax.Obganism.Analyzing
/// Odepax.Obganism.Parsing.Definitions
/// Odepax.Obganism.Parsing
/// Odepax.Obganism.CodeGeneration
///
/// Odepax.Extensions.Obganism.Lexing
/// Odepax.Extensions.Obganism.Analyzing
/// Odepax.Extensions.Obganism.Parsing
/// Odepax.Extensions.Obganism.CodeGeneration
namspace Odepax.Obganism {
	[Flags] enum TokenType : byte {
		None                   = 0b_0000_0000,
		BlockStart             = 0b_0000_0001,
		BlockEnd               = 0b_0000_0010,
		ListStart              = 0b_0000_0011,
		ListEnd                = 0b_0000_0100,
		TypeIntroducer         = 0b_0000_0101,
		ModifierListIntroducer = 0b_0000_0110,
		SectionSeparator       = 0b_0000_0111,
		Escaper                = 0b_0000_1000,
		String                 = 0b_0000_1001, // No "Regexp" or "Pattern" token => use string instead.
		Word                   = 0b_0001_0000,
			OfKeyword          = 0b_0001_0001,
		Number                 = 0b_0010_0000,
			Int                = 0b_0110_0000,
				PositiveInt	   = 0b_0110_0001,
			Float              = 0b_1010_0000
	}

	struct Token {
		readonly TokenType Type;
		readonly string? Value;

		readonly ulong Line;
		readonly ulong Column;
		readonly ulong Position;
	}

	//
	// BEWARE FLYING!
	// ----
	// All these methods should be async!
	//

	static class Lexing {
		// Don't: static IEnumerable<Token> ConvertFrom(string input) => ConvertFrom(new StringReader(input));
		// Or don't use a lazy enumerable as return type.
		// Don't: static IEnumerable<Token> ConvertFrom(Stream input) => ConvertFrom(new StreamReader(input));

		static IEnumerable<Token> ConvertFrom(TextReader input) {
			throw new NotImplementedException();
		}
	}

	static class Analyzing {}
	
	static class Parsing {
		// Don't: static IEnumerable<Object> ConvertFrom(string input) => ConvertFrom(Lexing.ConvertFrom(input));
		// Don't: static IEnumerable<Object> ConvertFrom(Stream input) => ConvertFrom(Lexing.ConvertFrom(input));
		// Don't: static IEnumerable<Object> ConvertFrom(TextReader input) => ConvertFrom(Lexing.ConvertFrom(input));

		static IEnumerable<Object> ConvertFrom(IEnumerable<Token> input) {
			throw new NotImplementedException();
		}
	}
	
	static class CodeGeneration {}
}

namspace Odepax.Extensions.Obganism {
	static class LexingExtensions {
		// Don't: static IEnumerable<Token> ConvertToTokens(this string input) => Lexing.ConvertFrom(input);
		// Don't: static IEnumerable<Token> ConvertToTokens(this Stream input) => Lexing.ConvertFrom(input);
		static IEnumerable<Token> ConvertToTokens(this TextReader input) => Lexing.ConvertFrom(input);
	}

	static class AnalyzingExtensions {}
	
	static class ParsingExtensions {
		// Don't: static IEnumerable<Object> ConvertToObjects(this string input) => Parsing.ConvertFrom(input);
		// Don't: static IEnumerable<Object> ConvertToObjects(this Stream input) => Parsing.ConvertFrom(input);
		// Don't: static IEnumerable<Object> ConvertToObjects(this TextReader input) => Parsing.ConvertFrom(input);
		static IEnumerable<Object> ConvertToObjects(this IEnumerable<Token> input) => Parsing.ConvertFrom(input);
	}
	
	static class CodeGenerationExtensions {}
}
