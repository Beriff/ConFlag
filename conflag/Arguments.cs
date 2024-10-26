namespace ConFlag
{
	public class Arguments
	{
		public List<char> Flags { get; set; } = [];
		public Dictionary<string, string?> Options { get; set; } = [];
		public List<string> Commands { get; set; } = [];
		public Arguments(string[] args)
		{
			foreach (var arg in args)
			{
				if (arg.StartsWith("--"))
				{
					string? value = null;
					string option = "";

					if(arg.Contains('='))
					{
						int index = arg.IndexOf('=');
						value = arg[(index + 1)..];
						option = arg[2..index];
					} else
					{
						option = arg[2..];
					}

					if (Options.ContainsKey(option))
						continue;

					Options.Add(option, value);
				}
				else if (arg.StartsWith('-'))
					foreach (var flag in arg[1..])
					{
						if(!Flags.Contains(flag))
							Flags.Add(flag);
					}
				else
					Commands.Add(arg);
			}
		}
	}
}
