using System.Xml.Linq;
using rule_engine.app;
using Xunit;

namespace rule_engine.tests;

public class XmlValidatorTests
{
    [Fact]
    public void ValidateDocument_WhenNoViolations_ReturnsEmptyList()
    {
        // Arrange
        var xml = @"
        <root>
            <contentItemRef category='A'/>
            <contentItemRef category='B'/>
        </root>";
        
        var document = XDocument.Parse(xml);
        var rules = new List<TemplateRule>
        {
            new TemplateRule("A", "C")
        };
        var validator = new XmlValidator(document, rules);

        // Act
        var result = validator.ValidateDocument();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void ValidateDocument_WhenForbiddenSiblingExists_ReturnsViolation()
    {
        // Arrange
        var xml = @"
        <root>
            <contentItemRef category='A'/>
            <contentItemRef category='C'/>
        </root>";
        
        var document = XDocument.Parse(xml);
        var rules = new List<TemplateRule>
        {
            new TemplateRule("A", "C")
        };
        var validator = new XmlValidator(document, rules);

        // Act
        var result = validator.ValidateDocument();

        // Assert
        Assert.Single(result);
        Assert.Contains("cannot have a sibling", result[0]);
    }

    [Fact]
    public void GetAllowedTemplates_WhenNodeHasRequiredCousins_ReturnsCousinCategories()
    {
        // Arrange
        var xml = @"
        <root>
            <contentItemRef category='A'/>
        </root>";
        
        var document = XDocument.Parse(xml);
        var rules = new List<TemplateRule>
        {
            new TemplateRule
            {
                Category = "A",
                RequiredCousinCategory = "CousinCategory"
            }
        };
        var validator = new XmlValidator(document, rules);

        // Act
        var result = validator.GetAllowedTemplates("//contentItemRef[@category='A']");

        // Assert
        Assert.Single(result);
        Assert.Contains("CousinCategory", result);
    }

    [Fact]
    public void GetAllowedTemplates_WhenNodeNotFound_ReturnsEmptyList()
    {
        // Arrange
        var xml = "<root></root>";
        var document = XDocument.Parse(xml);
        var rules = new List<TemplateRule>();
        var validator = new XmlValidator(document, rules);

        // Act
        var result = validator.GetAllowedTemplates("//nonExistentNode");

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void CanMoveNode_WhenNodeAndNewParentExist_ReturnsTrueIfAllowed()
    {
        // Arrange
        var xml = @"
        <root>
            <parent category='A'>
                <contentItemRef category='B'/>
            </parent>
            <newParent category='C'/>
        </root>";
        
        var document = XDocument.Parse(xml);
        var validator = new XmlValidator(document, new List<TemplateRule>());

        // Act
        var result = validator.CanMoveNode("//contentItemRef[@category='B']", "//newParent");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CanMoveNode_WhenNodeOrNewParentDoesNotExist_ReturnsFalse()
    {
        // Arrange
        var xml = "<root></root>";
        var document = XDocument.Parse(xml);
        var validator = new XmlValidator(document, new List<TemplateRule>());

        // Act
        var result = validator.CanMoveNode("//nonExistentNode", "//nonExistentParent");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CanMoveNode_WhenSiblingWithSameCategoryExists_ReturnsFalse()
    {
        // Arrange
        var xml = @"
        <root>
            <newParent>
                <contentItemRef category='B'/>
            </newParent>
        </root>";
        
        var document = XDocument.Parse(xml);
        var validator = new XmlValidator(document, new List<TemplateRule>());

        // Act
        var result = validator.CanMoveNode("//contentItemRef[@category='B']", "//newParent");

        // Assert
        Assert.False(result);
    }
}