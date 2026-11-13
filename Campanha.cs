using System;

    class Campaign
{       
    public string Name { get; set; }
    public string Description { get; set; }
    public string TextModelCampain {get; set; }
    public CampaignModel Model { get; set; }
    public CampaignStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime PublicationDate { get; set; }
    public string? ImageUrl { get; set; }

}