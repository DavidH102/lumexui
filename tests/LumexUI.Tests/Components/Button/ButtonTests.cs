// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.Extensions.DependencyInjection;

using TailwindMerge;

namespace LumexUI.Tests.Components;

public class ButtonTests : TestContext
{
	public ButtonTests()
	{
		Services.AddSingleton<TwMerge>();
	}

    [Fact]
    public void Button_ShouldRenderCorrectly()
    {
        var action = () => RenderComponent<LumexButton>();

        action.Should().NotThrow();
    }

	[Fact]
	public void Button_Disabled_ShouldHaveDisabledAttribute()
	{
		var cut = RenderComponent<LumexButton>( p => p
			.Add( p => p.Disabled, true )
		);

		var button = cut.Find( "button" );

		button.HasAttribute( "disabled" ).Should().BeTrue();
	}

	[Fact]
	public void Button_Disabled_ShouldNotTriggerClick()
	{
		var clicked = false;
		var cut = RenderComponent<LumexButton>( p => p
			.Add( p => p.Disabled, true )
			.Add( p => p.OnClick, () => clicked = true )
		);

		var button = cut.Find( "button" );
		button.Click();

        clicked.Should().BeFalse();
	}

    [Fact]
    public void Button_NotDisabled_ShouldTriggerClick()
    {
        var clicked = false;
        var cut = RenderComponent<LumexButton>( p => p
            .Add( p => p.Disabled, false )
            .Add( p => p.OnClick, () => clicked = true )
        );

        var button = cut.Find( "button" );
        button.Click();

        clicked.Should().BeTrue();
    }

    [Fact]
	public void Button_Type_ShouldHaveCorrectTypeAttribute()
	{
		var cut = RenderComponent<LumexButton>( p => p
			.Add( p => p.Type, ButtonType.Submit )
		);

		var button = cut.Find( "button" );

		button.GetAttribute( "type" ).Should().Be( ButtonType.Submit.ToDescription() );
	}

    [Fact]
    public void Button_StartIcon_ShouldRenderWithStartIcon()
    {
        var cut = RenderComponent<LumexButton>( p => p
            .Add( p => p.StartIcon, Icons.Rounded.Person )
        );

        cut.FindComponent<LumexIcon>();
    }

    [Fact]
    public void Button_EndIcon_ShouldRenderWithEndIcon()
    {
        var cut = RenderComponent<LumexButton>( p => p
            .Add( p => p.EndIcon, Icons.Rounded.Person )
        );

        cut.FindComponent<LumexIcon>();
    }
}