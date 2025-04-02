using System.ComponentModel.DataAnnotations;

namespace App_Store.Api.DTOs;

public record class AppDto
(
    int Id,
    string Name,
    string GenreName,
    double Price,
    DateOnly ReleaseDate
);
