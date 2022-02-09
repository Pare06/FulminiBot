using Discord;
using Discord.WebSocket;

namespace FulminiBot
{
	internal partial class MainBot
	{
		private async Task ReplyAsync(string text)
		{
			if (context.IsPrivate)
				await message.Author.SendMessageAsync(text);
			else
				await context.Channel.SendMessageAsync(text);
		}

		private async Task DeleteMessageAsync() => await message.DeleteAsync();
		
		private async Task MuteAuthorAsync() => await MuteAuthorAsync(new TimeSpan(0, 5, 0)); // 5 minuti - default

		private async Task MuteAuthorAsync(TimeSpan time)
		{
			IRole role = Client.GetGuild(GuildId).GetRole(0 /* da aggiungere */ );
			SocketGuildUser sgu = (SocketGuildUser)message.Author;
			await sgu.AddRoleAsync(role);

			await Task.Delay(time.Milliseconds);

			await sgu.RemoveRoleAsync(role);
		}
	}
}
