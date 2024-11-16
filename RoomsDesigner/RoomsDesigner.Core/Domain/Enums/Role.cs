using System.ComponentModel;

namespace RoomsDesigner.Core.Domain.Enums
{
	public enum Role
	{
		None = 0,

		[Description("Room's administrator")]
		Admin = 1,

		[Description("Room's particicpant")]
		Participant = 2
	}
}
