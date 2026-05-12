namespace Lecture.Models;

public sealed record BookBase(
    string Title,
    string Author,
    string[] Categories,
    string Language,
    string PdfLink);
