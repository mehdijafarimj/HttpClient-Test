﻿namespace HttpClient_Test.Domain;

public class CreateTaskDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}
