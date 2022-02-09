using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace FulminiBot
{
	internal partial class MainBot
	{
		// Variabili per Commands.cs
#pragma warning disable CS8618
		private SocketUserMessage message;
		private SocketCommandContext context;
#pragma warning restore CS8618

		public static void Main() => new MainBot().RunBotAsync().GetAwaiter().GetResult();

		private async Task RunBotAsync()
		{
			Client = new();

			RegisterCommands();

			await Client.LoginAsync(TokenType.Bot, Token.BotToken);
			await Client.StartAsync();

			await Task.Delay(-1);
		}

		private void RegisterCommands() => Client.MessageReceived += HandleCommandAsync;

		private async Task HandleCommandAsync(SocketMessage arg)
		{
			message = (SocketUserMessage)arg;
			context = new(Client, message);

			if (message.Author.IsBot) return;

			if (context.IsPrivate)
			{
				if (message.Author.Id == PareId) 
					await ReplyAsync("fratm");
				else
					await message.Author.SendMessageAsync("solo quel malato di pare mi può scrivere in privato per ora");

				return;
			}

			await HandleChatMessageAsync();
		}
	}
}
