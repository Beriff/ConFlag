# ConFlag

**ConFlag** is a simple single-class package to help you lightweightly manage your command line arguments.

## Usage
Command line arguments are split into three groups: *flags*, *options* and *commands*.

If an argument starts with a single dash (-), followed by one or more letters, then they are interpreted as *flags*. Accessed via `Arguments.Flags` list.

If an argument starts with a double dash (--), followed by a string of text, then it is interpreted as an *option*. Option can optionally be followed by an equals sign (=) with a string of text following it (for example `--sort=reverse`), then the value after the equals sign will be interpreted as the current option's value. Accessed via `Arguments.Options` (`string`, `string?`) dictionary.

Lastly, a string of text not preceded by a dash or double dash is interpreted as a command (subcommand). Accessed via `Arguments.Commands` list.

```cs

using System;
using ConFlag;

namespace Example {

    class Example {
        static void Main(string[] args) {

            // create the ConFlag Arguments class
            Arguments arguments = new(args);

            // check if -h or --help were passed as arguments
            if(
                arguments.Flags.Contains('h') ||
                arguments.Options.ContainsKey("help")
                ) 
            {
                Console.WriteLine("Example program usage: ...");
            }
        }
    }
}

```
