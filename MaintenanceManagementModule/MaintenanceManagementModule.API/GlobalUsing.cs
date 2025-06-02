// libraries
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using FluentValidation.AspNetCore;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore.Internal;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using System.Text;
global using FluentValidation;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.OpenApi.Models;
global using Swashbuckle.AspNetCore.SwaggerGen;
global using Microsoft.AspNetCore.Mvc.Filters;
global using System.Net;

// Namespace
global using MaintenanceManagementModule.Application.Interfaces;
global using MaintenanceManagementModule.Application.Services;
global using MaintenanceManagementModule.Domain.DTO;
global using MaintenanceManagementModule.Domain.Constant;
global using MaintenanceManagementModule.Domain.Interfaces;
global using MaintenanceManagementModule.Infrastructure.Repositories;
global using MaintenanceManagementModule.Domain.Entities;
global using MaintenanceManagementModule.Infrastructure.Data;
global using MaintenanceManagementModule.API.Extensions;
global using Microsoft.AspNetCore.Cors.Infrastructure;
global using MaintenanceManagementModule.Application.Helpers;
global using MaintenanceManagementModule.API.ExceptionFilter;