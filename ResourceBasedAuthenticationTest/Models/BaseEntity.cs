﻿using System;

namespace ResourceBasedAuthenticationTest.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsSoftDeleted { get; set; }
    }
}