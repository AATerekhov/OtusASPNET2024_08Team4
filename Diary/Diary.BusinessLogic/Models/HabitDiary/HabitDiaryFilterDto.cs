﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BusinessLogic.Models.UserJournal
{
    public class HabitDiaryFilterDto
    {
        public Guid Id { get; init; }
        public string Description { get; init; }
        public Guid RoomId { get; init; }

        public Guid DiaryOwnerId { get; init; }
        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}