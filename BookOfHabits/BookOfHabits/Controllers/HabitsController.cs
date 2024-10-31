using BookOfHabitsMicroservice.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BookOfHabits.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HabitsController(IHabitsApplicationService habitsApplicationService,
                                    IInstallCardApplicationService installCardApplicationService):ControllerBase
    {

    }
}
