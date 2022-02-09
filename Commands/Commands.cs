namespace FulminiBot
{
	internal partial class MainBot
	{
		private delegate Task Command();

		private async Task HandleChatMessageAsync()
		{
			string[] keywords = { "cancro", "ronaldo" };
			Command[] commands = Commands(); // si capisce comunque meglio delle lezioni della scamuzzi

			for (int i = 0; i < keywords.Length; i++)
			{
				if (message.Content.StartsWith(keywords[i])) await commands[i]();
			}
		}

		private Command[] Commands()
		{
			return new Command[]
			{
				// non ho voglia di fare un cazzo
				Ronaldo, Ronaldo
			};
		}

		private async Task Ronaldo() => await ReplyAsync("SIUUUUM");
	}
}
