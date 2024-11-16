using System.ComponentModel;

namespace RoomsDesigner.Core.Domain.Enums
{
	public enum HabitCategory
	{
		None = 0,

		[Description("Nutrition, sleep, well-being, hygiene and etc.")]
		Health = 1,

		[Description("Courses, upgrading hard skills and etc.")]
		Education = 2,

		[Description("Any habits, which are directly related with physical activity and etc.")]
		Sport = 3,

		[Description("Productivity, professional development, communication and etc.")]
		Work = 4,

		[Description("Interaction with loved ones, conflict resolution, maintaining relationships and etc.")]
		Relationship = 5,

		[Description("Reading, meditation and mindfulness, goal-setting and planning, self-development, personal growth and etc.")]
		SelfDevelopment = 6,

		[Description("Budgeting, saving and investing, debt management and etc.")]
		FinancialBehavior = 7,
		
		[Description("Hobbies, interests, rest, travel, media consumption and etc.")]
		Entertainment = 8,

		[Description("Cleaning, organizing, waste sorting, storage, decluttering and etc.")]
		Household = 9,

		[Description("Positive thinking, forgiveness and letting go of grudges, self-acceptance, self-care and etc.")]
		EmotionalWellBeing = 10,

		[Description("Any habits, which are not suitable for other categories")]
		Custom = 11,
	}
}
