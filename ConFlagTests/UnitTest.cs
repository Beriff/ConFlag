using ConFlag;

namespace ConFlagTests
{
	[TestClass]
	public class UnitTest
	{
		[TestMethod]
		public void FlagTest()
		{
			Arguments args = new(["-a", "-b", "-abc"]);
			Assert.IsTrue(args.Flags.SequenceEqual(['a', 'b', 'c']));
		}

		[TestMethod]
		public void OptionTest()
		{
			Arguments args = new(["--option_a=value_a", "--option_b"]);
			Assert.IsTrue(args.Options.Keys.SequenceEqual(["option_a", "option_b"]));
			Assert.IsTrue(args.Options.Values.SequenceEqual(["value_a", null]));
		}

		[TestMethod]
		public void CommandTest()
		{
			Arguments args = new(["subcommand_a", "subcommand_b"]);
			Assert.IsTrue(args.Commands.SequenceEqual(["subcommand_a", "subcommand_b"]));
		}

		[TestMethod]
		public void CompoundTest()
		{
			Arguments args = new(["sub", "-abc", "-b", "-d", "--opt=val", "--toggle"]);
			Assert.IsTrue(args.Flags.SequenceEqual(['a', 'b', 'c', 'd']));
			Assert.IsTrue(args.Options.Keys.SequenceEqual(["opt", "toggle"]));
			Assert.IsTrue(args.Options.Values.SequenceEqual(["val", null]));
			Assert.IsTrue(args.Commands.SequenceEqual(["sub"]));
		}
	}
}