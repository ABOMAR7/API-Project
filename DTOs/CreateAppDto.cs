using System.ComponentModel.DataAnnotations;

namespace App_Store.Api.DTOs;

public record class CreateAppDto
(
    [Required][StringLength(27)] string Name,
    int GenresId,
    [Required][Range(1, 250)] double Price,
    [Required] DateOnly ReleaseDate
);
