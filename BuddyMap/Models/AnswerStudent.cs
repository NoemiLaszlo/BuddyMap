﻿namespace BuddyMap.Models
{
    public class AnswerStudent
    {
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}