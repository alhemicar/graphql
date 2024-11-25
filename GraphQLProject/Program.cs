using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Mutation;
using GraphQLProject.Schema;
using GraphQLProject.Services;
using GraphQLProject.Type;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IReservationRepository, ReservationRepository>();

builder.Services.AddTransient<MenuType>();
builder.Services.AddTransient<CategoryType>();
builder.Services.AddTransient<ReservationType>();

builder.Services.AddTransient<MenuQuery>();
builder.Services.AddTransient<CategoryQuery>();
builder.Services.AddTransient<ReservationQuery>();
builder.Services.AddTransient<RootQuery>();

builder.Services.AddTransient<MenuMutation>();
builder.Services.AddTransient<CategoryMutation>();
builder.Services.AddTransient<ReservationMutation>();
builder.Services.AddTransient<RootMutation>();

builder.Services.AddTransient<MenuInputType>();
builder.Services.AddTransient<CategoryInputType>();
builder.Services.AddTransient<ReservationInputType>();

builder.Services.AddTransient<ISchema, RootSchema>();

builder.Services.AddGraphQL(b => b.AddAutoSchema<ISchema>().AddSystemTextJson());

builder.Services.AddDbContext<GraphQLDbContext>(
    option => option.UseSqlServer(
        builder.Configuration.GetConnectionString("GraphQLDbContextConnection")
    )
);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseGraphiQl("/graphql");

app.UseGraphQL<ISchema>();

app.UseAuthorization();

app.MapControllers();

app.Run();