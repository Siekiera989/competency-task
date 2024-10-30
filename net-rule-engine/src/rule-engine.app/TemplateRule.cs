namespace rule_engine.app;

public class TemplateRule
{
    public TemplateRule()
    {
    }

    public TemplateRule(string category, string forbiddenSiblingCategory)
    {
        Category = category;
        ForbiddenSiblingCategory = forbiddenSiblingCategory;
    }

    public string Category { get; init; }
    public string Subcategory { get; set; }
    public string ForbiddenSiblingCategory { get; init; }
    public string RequiredCousinCategory { get; init; }
}