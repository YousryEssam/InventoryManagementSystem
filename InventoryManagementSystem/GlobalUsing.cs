global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Authorization;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

global using InventoryManagementSystem.Enums;
global using InventoryManagementSystem.Models;
global using InventoryManagementSystem.DataSource;
global using InventoryManagementSystem.GenericRepositories;

global using InventoryManagementSystem.DTOs.Account;
global using InventoryManagementSystem.DTOs.ProductDTOs;
global using InventoryManagementSystem.DTOs.WarehouseDTOs;
global using InventoryManagementSystem.DTOs.WarehouseProduct;

global using InventoryManagementSystem.Repositories.Interfaces;
global using InventoryManagementSystem.Repositories.Implementations;

global using InventoryManagementSystem.CQRS.Queries.ProductQueries;
global using InventoryManagementSystem.CQRS.Queries.WarehouseQueries;
global using InventoryManagementSystem.CQRS.Commands.WarehouseCommands;
global using InventoryManagementSystem.CQRS.Queries.WarehouseProductQueries;
global using InventoryManagementSystem.CQRS.Commands.WarehouseProductCommands;


global using InventoryManagementSystem.ViewModels.GeneralViewModels;
global using InventoryManagementSystem.ViewModels.ProductViewModels;
global using InventoryManagementSystem.ViewModels.AccountViewModels;
global using InventoryManagementSystem.ViewModels.WarehouseViewModels;
global using InventoryManagementSystem.ViewModels.WarehouseProductViewModels;
global using InventoryManagementSystem.ViewModels.InventoryTransactionViewModels;


