using Microsoft.AspNetCore.Components;

namespace blazor_travel.Shared;

public partial class SearchResultsPaging
{
    [Parameter]
    public int CurrentPage { get; set; }

    [Parameter]
    public int TotalPages { get; set; }

    [Parameter]
    public int TotalResults { get; set; }
    
    [Parameter]
    public EventCallback<int> OnNumberResultsChanged { get; set; }
    
    [Parameter]
    public EventCallback<int> OnPageChanged { get; set; }
    
    [Parameter]
    public int TotalPerPage { get; set; }

    private async Task NumberResultsChanged(ChangeEventArgs arg)
    {
        await OnNumberResultsChanged.InvokeAsync(Convert.ToInt32(arg.Value));
    }

    private async Task FirstClicked()
    {
        await OnPageChanged.InvokeAsync(1);
    }

    private async Task PageClicked(int pageNumber)
    {
        await OnPageChanged.InvokeAsync(pageNumber);
    }
    
    private async Task PreviousClicked()
    {
        await OnPageChanged.InvokeAsync(CurrentPage--);

    }

    private async Task NextClicked()
    {
        await OnPageChanged.InvokeAsync(CurrentPage++);
    }
    private async Task LastClicked()
    {
        CurrentPage = TotalResults / TotalPerPage;
        if (CurrentPage > 15)
            CurrentPage = 15;
        
        await OnPageChanged.InvokeAsync(CurrentPage++);
    }
    
}