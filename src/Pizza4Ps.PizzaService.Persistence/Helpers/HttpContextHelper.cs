﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Pizza4Ps.PizzaService.Persistence.Helpers
{
    public static class HttpContextHelper
    {
        public static Guid? GetCurrentUserCollabId(this HttpContext context)
        {
            if (context == null)
            {
                return null;
            }
            var currentCollabID = context.User.FindFirstValue("CollabId");
            Guid.TryParse(currentCollabID, out var collabID);
            return collabID;
        }
        public static string? GetCurrentUserRoleName(this HttpContext context)
        {
            var roleName = context?.User.FindFirstValue(ClaimTypes.Role);
            if (roleName == null)
            {
                return null;
            }
            return roleName ?? null;
        }
        public static Guid? GetCurrentUserId(this HttpContext context)
        {
            var currentUserId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == null)
            {
                return null;
            }
            Guid.TryParse(currentUserId, out var userId);
            return userId;
        }
        public static Guid? GetCustomerId(this HttpContext context)
        {
            var currentUserId = context.User.FindFirstValue("CustomerId");
            if (currentUserId == null)
            {
                return null;
            }
            Guid.TryParse(currentUserId, out var userId);
            return userId;
        }
        public static Guid? GetStaffId(this HttpContext context)
        {
            var currentUserId = context.User.FindFirstValue("StaffId");
            if (currentUserId == null)
            {
                return null;
            }
            Guid.TryParse(currentUserId, out var userId);
            return userId;
        }
        public static Guid? GetAppUserCustomerIdId(this HttpContext context)
        {
            var currentUserId = context.User.FindFirstValue("AppUserCustomerId");
            if (currentUserId == null)
            {
                return null;
            }
            Guid.TryParse(currentUserId, out var userId);
            return userId;
        }
        public static string? GetCurrentUserName(this HttpContext context)
        {
            var currentUserName = context.User.FindFirstValue(ClaimTypes.Name);
            if (currentUserName == null)
            {
                return null;
            }
            return currentUserName;
        }
    }
}
