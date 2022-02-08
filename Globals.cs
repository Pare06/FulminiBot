global using static FulminiBot.Globals;
using Discord.Commands;
using Discord.WebSocket;

namespace FulminiBot
{
	#pragma warning disable CS8618 // mocc a sorrt

	internal static class Globals
	{
		public static DiscordSocketClient Client { get; set; }
		public static CommandService Commands { get; set; }

		public const ulong PareId = 566905651310362656;
		public const ulong GuildId = 0; // da aggiungere
	}
}
