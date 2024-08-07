﻿// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class TextBox
{
    private readonly static string _base = ElementClass.Empty()
        .Add( "group" )
        .Add( "relative" )
        .Add( "flex" )
        .Add( "flex-col" )
        .Add( "data-[hidden=true]:hidden" )
        .ToString();

    private readonly static string _label = ElementClass.Empty()
        .Add( "absolute" )
        .Add( "z-10" )
        .Add( "block" )
        .Add( "text-small" )
        .Add( "text-foreground-500" )
        .Add( "origin-top-left" )
        .Add( "pointer-events-none" )
        .Add( "subpixel-antialiased" )
        .Add( "pe-2" )
        .Add( "max-w-full" )
        .Add( "text-ellipsis" )
        .Add( "overflow-hidden" )
        .Add( "group-data-[filled-focused=true]:pointer-events-auto" )
        // transition
        .Add( "will-change-auto" )
        .Add( "transition-[transform,color,left,opacity]" )
        .Add( "motion-reduce:transition-none" )
        .ToString();

    private readonly static string _mainWrapper = ElementClass.Empty()
        .Add( "h-full" )
        .ToString();

    private readonly static string _inputWrapper = ElementClass.Empty()
        .Add( "relative" )
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "px-3" )
        .Add( "gap-3" )
        .Add( "w-full" )
        .Add( "shadow-sm" )
        .Add( "cursor-text" )
        // transition
        .Add( "transition-[background]" )
        .Add( "motion-reduce:transition-none" )
        .ToString();

    private readonly static string _innerWrapper = ElementClass.Empty()
        .Add( "inline-flex" )
        .Add( "items-center" )
        .Add( "w-full" )
        .Add( "h-full" )
        .Add( "data-[has-clear-button=true]:pe-7" )
        .ToString();

    private readonly static string _input = ElementClass.Empty()
        .Add( "w-full" )
        .Add( "font-normal" )
        .Add( "bg-transparent" )
        .Add( "focus-visible:outline-none" )
        .Add( "placeholder:text-foreground-500" )
        .Add( "autofill:bg-transparent" )
        .Add( "data-[has-start-content=true]:ps-1.5" )
        .Add( "data-[has-end-content=true]:pe-1.5" )
        .ToString();

    private readonly static string _clearButton = ElementClass.Empty()
        .Add( "p-0.5" )
        //.Add( "-m-2" )
        .Add( "z-10" )
        .Add( "absolute" )
        .Add( "end-1.5" )
        .Add( "select-none" )
        .Add( "hover:!opacity-100" )
        .Add( "active:!opacity-focus" )
        .Add( "rounded-full" )
        // transition
        .Add( "transition-opacity" )
        .Add( "motion-reduce:transition-none" )
        // focus ring
        .Add( Utils.FocusVisible )
        .ToString();

    private readonly static string _helperWrapper = ElementClass.Empty()
        .Add( "relative" )
        .Add( "flex" )
        .Add( "flex-col" )
        .Add( "gap-1.5" )
        .Add( "p-1" )
        .ToString();

    private readonly static string _description = ElementClass.Empty()
        .Add( "text-tiny" )
        .Add( "text-foreground-400" )
        .ToString();

    private readonly static string _errorMessage = ElementClass.Empty()
        .Add( "text-tiny" )
        .Add( "text-danger" )
        .ToString();

    private readonly static string _disabled = ElementClass.Empty()
        .Add( "opacity-disabled" )
        .Add( "pointer-events-none" )
        .ToString();

    private readonly static string _fullWidth = ElementClass.Empty()
        .Add( "w-full" )
        .ToString();

    private static ElementClass GetSizeStyles( Size size, string slot )
    {
        return size switch
        {
            Size.Small => ElementClass.Empty()
                .Add( "h-8 min-h-8 rounded-small", when: slot is nameof( _inputWrapper ) )
                .Add( "text-small", when: slot is nameof( _input ) )
                .Add( "text-medium", when: slot is nameof( _clearButton ) ),

            Size.Medium => ElementClass.Empty()
                .Add( "h-10 min-h-10 rounded-medium", when: slot is nameof( _inputWrapper ) )
                .Add( "text-small", when: slot is nameof( _input ) )
                .Add( "text-large", when: slot is nameof( _clearButton ) ),

            Size.Large => ElementClass.Empty()
                .Add( "h-12 min-h-12 rounded-large", when: slot is nameof( _inputWrapper ) )
                .Add( "text-medium", when: slot is nameof( _input ) )
                .Add( "text-large", when: slot is nameof( _clearButton ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetRadiusStyles( Radius? radius, string slot )
    {
        return radius switch
        {
            Radius.None => ElementClass.Empty()
                .Add( "rounded-none", when: slot is nameof( _inputWrapper ) ),

            Radius.Small => ElementClass.Empty()
                .Add( "rounded-small", when: slot is nameof( _inputWrapper ) ),

            Radius.Medium => ElementClass.Empty()
                .Add( "rounded-medium", when: slot is nameof( _inputWrapper ) ),

            Radius.Large => ElementClass.Empty()
                .Add( "rounded-large", when: slot is nameof( _inputWrapper ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetClearableStyles( string slot )
    {
        return ElementClass.Empty()
            .Add( "peer", when: slot is nameof( _input ) )
            .Add( "peer-data-[filled=true]:opacity-focus", when: slot is nameof( _clearButton ) );
    }

    private static ElementClass GetInvalidStyles( string slot )
    {
        return ElementClass.Empty()
            .Add( "!placeholder:text-danger !text-danger", when: slot is nameof( _input ) )
            .Add( "!text-danger", when: slot is nameof( _label ) );
    }

    private static ElementClass GetRequiredStyles( string slot )
    {
        return ElementClass.Empty()
            .Add( "after:content-['*'] after:text-danger after:ms-0.5", when: slot is nameof( _label ) );
    }

    private static ElementClass GetVariantStyles( InputVariant variant, string slot )
    {
        return variant switch
        {
            InputVariant.Flat => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "bg-default-100" )
                    .Add( "hover:bg-default-200" )
                    .Add( "group-data-[focus=true]:bg-default-100" ), when: slot is nameof( _inputWrapper ) ),
            // focus ring
            // TODO: Seems like we need a JavaScript call similar to React Aria `useFocusVisible` hook
            //.Add( Utils.GroupDataFocusVisible ) )

            InputVariant.Outlined => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "border-2" )
                    .Add( "border-default-200" )
                    .Add( "hover:border-default-300" )
                    .Add( "transition-colors" )
                    .Add( "group-data-[focus=true]:border-default-foreground" ), when: slot is nameof( _inputWrapper ) ),

            InputVariant.Underlined => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "!px-1" )
                    .Add( "!pb-0" )
                    .Add( "!rounded-none" )
                    .Add( "relative" )
                    .Add( "border-b-2" )
                    .Add( "border-default-200" )
                    .Add( "hover:border-default-300" )
                    .Add( "after:w-0" )
                    .Add( "after:origin-center" )
                    .Add( "after:bg-default-foreground" )
                    .Add( "after:absolute" )
                    .Add( "after:left-1/2" )
                    .Add( "after:-translate-x-1/2" )
                    .Add( "after:-bottom-[2px]" )
                    .Add( "after:h-[2px]" )
                    .Add( "after:transition-[width]" )
                    .Add( "group-data-[focus=true]:after:w-full" ), when: slot is nameof( _inputWrapper ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetVariantInvalidStyles( InputVariant variant, string slot )
    {
        return variant switch
        {
            InputVariant.Flat => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "!bg-danger-50" )
                    .Add( "hover:!bg-danger-100" )
                    .Add( "group-data-[focus=true]:!bg-danger-50" ), when: slot is nameof( _inputWrapper ) ),

            InputVariant.Outlined => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "!border-danger" )
                    .Add( "group-data-[focus=true]:!border-danger" ), when: slot is nameof( _inputWrapper ) ),

            InputVariant.Underlined => ElementClass.Empty()
                .Add( "after:!bg-danger", when: slot is nameof( _inputWrapper ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetVariantFlatByColorStyles( ThemeColor color, string slot )
    {
        return color switch
        {
            ThemeColor.Default => ElementClass.Empty()
                .Add( "[&:not(placeholder-shown)]:text-default-foreground", when: slot is nameof( _input ) ),

            ThemeColor.Primary => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "text-primary" )
                    .Add( "bg-primary-50" )
                    .Add( "hover:bg-primary-100" )
                    .Add( "placeholder:text-primary" )
                    .Add( "group-data-[focus=true]:bg-primary-50" ), when: slot is nameof( _inputWrapper ) )
                .Add( "placeholder:text-primary", when: slot is nameof( _input ) )
                .Add( "text-primary", when: slot is nameof( _label ) ),

            ThemeColor.Secondary => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "text-secondary" )
                    .Add( "bg-secondary-50" )
                    .Add( "hover:bg-secondary-100" )
                    .Add( "placeholder:text-secondary" )
                    .Add( "group-data-[focus=true]:bg-secondary-50" ), when: slot is nameof( _inputWrapper ) )
                .Add( "placeholder:text-secondary", when: slot is nameof( _input ) )
                .Add( "text-secondary", when: slot is nameof( _label ) ),

            ThemeColor.Success => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "text-success-600" )
                    .Add( "dark:text-success" )
                    .Add( "bg-success-50" )
                    .Add( "hover:bg-success-100" )
                    .Add( "placeholder:text-success-600" )
                    .Add( "group-data-[focus=true]:bg-success-50" ), when: slot is nameof( _inputWrapper ) )
                .Add( "placeholder:text-success-600 dark:placeholder:text-success", when: slot is nameof( _input ) )
                .Add( "text-success-600 dark:text-success", when: slot is nameof( _label ) ),

            ThemeColor.Warning => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "text-warning-600" )
                    .Add( "dark:text-warning" )
                    .Add( "bg-warning-50" )
                    .Add( "hover:bg-warning-100" )
                    .Add( "placeholder:text-warning-600" )
                    .Add( "group-data-[focus=true]:bg-warning-50" ), when: slot is nameof( _inputWrapper ) )
                .Add( "placeholder:text-warning-600 dark:placeholder:text-warning", when: slot is nameof( _input ) )
                .Add( "text-warning-600 dark:text-warning", when: slot is nameof( _label ) ),

            ThemeColor.Danger => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "text-danger-600" )
                    .Add( "dark:text-danger" )
                    .Add( "bg-danger-50" )
                    .Add( "hover:bg-danger-100" )
                    .Add( "placeholder:text-danger-600" )
                    .Add( "group-data-[focus=true]:bg-danger-50" ), when: slot is nameof( _inputWrapper ) )
                .Add( "placeholder:text-danger-600 dark:placeholder:text-danger", when: slot is nameof( _input ) )
                .Add( "text-danger-600 dark:text-danger", when: slot is nameof( _label ) ),

            ThemeColor.Info => ElementClass.Empty()
                .Add( ElementClass.Empty()
                    .Add( "text-info" )
                    .Add( "bg-info-50" )
                    .Add( "hover:bg-info-100" )
                    .Add( "placeholder:text-info" )
                    .Add( "group-data-[focus=true]:bg-info-50" ), when: slot is nameof( _inputWrapper ) )
                .Add( "placeholder:text-info", when: slot is nameof( _input ) )
                .Add( "text-info", when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetVariantOutlinedByColorStyles( ThemeColor color, string slot )
    {
        return color switch
        {
            ThemeColor.Primary => ElementClass.Empty()
                .Add( "group-data-[focus=true]:border-primary", when: slot is nameof( _inputWrapper ) )
                .Add( "text-primary", when: slot is nameof( _label ) ),

            ThemeColor.Secondary => ElementClass.Empty()
                .Add( "group-data-[focus=true]:border-secondary", when: slot is nameof( _inputWrapper ) )
                .Add( "text-secondary", when: slot is nameof( _label ) ),

            ThemeColor.Success => ElementClass.Empty()
                .Add( "group-data-[focus=true]:border-success", when: slot is nameof( _inputWrapper ) )
                .Add( "text-success", when: slot is nameof( _label ) ),

            ThemeColor.Warning => ElementClass.Empty()
                .Add( "group-data-[focus=true]:border-warning", when: slot is nameof( _inputWrapper ) )
                .Add( "text-warning", when: slot is nameof( _label ) ),

            ThemeColor.Danger => ElementClass.Empty()
                .Add( "group-data-[focus=true]:border-danger", when: slot is nameof( _inputWrapper ) )
                .Add( "text-danger", when: slot is nameof( _label ) ),

            ThemeColor.Info => ElementClass.Empty()
                .Add( "group-data-[focus=true]:border-info", when: slot is nameof( _inputWrapper ) )
                .Add( "text-info", when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetVariantUnderlinedByColorStyles( ThemeColor color, string slot )
    {
        return color switch
        {
            ThemeColor.Default => ElementClass.Empty()
                .Add( "[&:not(placeholder-shown)]:text-foreground", when: slot is nameof( _input ) ),

            ThemeColor.Primary => ElementClass.Empty()
                .Add( "after:bg-primary", when: slot is nameof( _inputWrapper ) )
                .Add( "text-primary", when: slot is nameof( _label ) ),

            ThemeColor.Secondary => ElementClass.Empty()
                .Add( "after:bg-secondary", when: slot is nameof( _inputWrapper ) )
                .Add( "text-secondary", when: slot is nameof( _label ) ),

            ThemeColor.Success => ElementClass.Empty()
                .Add( "after:bg-success", when: slot is nameof( _inputWrapper ) )
                .Add( "text-success", when: slot is nameof( _label ) ),

            ThemeColor.Warning => ElementClass.Empty()
                .Add( "after:bg-warning", when: slot is nameof( _inputWrapper ) )
                .Add( "text-warning", when: slot is nameof( _label ) ),

            ThemeColor.Danger => ElementClass.Empty()
                .Add( "after:bg-danger", when: slot is nameof( _inputWrapper ) )
                .Add( "text-danger", when: slot is nameof( _label ) ),

            ThemeColor.Info => ElementClass.Empty()
                .Add( "after:bg-info", when: slot is nameof( _inputWrapper ) )
                .Add( "text-info", when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetLabelPlacementStyles( LabelPlacement labelPlacement, string slot )
    {
        return labelPlacement switch
        {
            LabelPlacement.Inside => ElementClass.Empty()
                .Add( "flex-col items-start justify-center", when: slot is nameof( _inputWrapper ) )
                .Add( "group-has-[label]:items-end", when: slot is nameof( _innerWrapper ) )
                .Add( "cursor-text group-data-[filled-focused=true]:scale-[0.85]", when: slot is nameof( _label ) ),

            LabelPlacement.Outside => ElementClass.Empty()
                .Add( "justify-end", when: slot is nameof( _base ) )
                .Add( "flex flex-col", when: slot is nameof( _mainWrapper ) )
                .Add( ElementClass.Empty()
                    .Add( "z-20" )
                    .Add( "top-1/2" )
                    .Add( "-translate-y-1/2" )
                    .Add( "group-data-[filled-focused=true]:left-0" ), when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetLabelPlacementInsideBySizeStyles( Size size, string slot )
    {
        return size switch
        {
            Size.Small => ElementClass.Empty()
                .Add( "h-12 py-1.5", when: slot is nameof( _inputWrapper ) )
                .Add( ElementClass.Empty()
                    .Add( "text-small" )
                    .Add( "group-data-[filled-focused=true]:-translate-y-[calc(50%_+_theme(fontSize.tiny)/2_-_8px)]" ), when: slot is nameof( _label ) ),

            Size.Medium => ElementClass.Empty()
                .Add( "h-14 py-2", when: slot is nameof( _inputWrapper ) )
                .Add( ElementClass.Empty()
                    .Add( "text-small" )
                    .Add( "group-data-[filled-focused=true]:-translate-y-[calc(50%_+_theme(fontSize.small)/2_-_6px)]" ), when: slot is nameof( _label ) ),

            Size.Large => ElementClass.Empty()
                .Add( "h-16 py-2.5", when: slot is nameof( _inputWrapper ) )
                .Add( ElementClass.Empty()
                    .Add( "text-medium" )
                    .Add( "group-data-[filled-focused=true]:-translate-y-[calc(50%_+_theme(fontSize.small)/2_-_8px)]" ), when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    private static ElementClass GetLabelPlacementOutsideBySizeStyles( Size size, string slot )
    {
        return size switch
        {
            Size.Small => ElementClass.Empty()
                .Add( "has-[label]:mt-[calc(theme(fontSize.small)_+_8px)]", when: slot is nameof( _base ) )
                .Add( ElementClass.Empty()
                    .Add( "text-tiny" )
                    .Add( "left-2" )
                    .Add( "group-data-[filled-focused=true]:-translate-y-[calc(100%_+_theme(fontSize.tiny)/2_+_16px)]" ), when: slot is nameof( _label ) ),

            Size.Medium => ElementClass.Empty()
                .Add( "has-[label]:mt-[calc(theme(fontSize.small)_+_10px)]", when: slot is nameof( _base ) )
                .Add( ElementClass.Empty()
                    .Add( "text-small" )
                    .Add( "left-3" )
                    .Add( "group-data-[filled-focused=true]:-translate-y-[calc(100%_+_theme(fontSize.small)/2_+_20px)]" ), when: slot is nameof( _label ) ),

            Size.Large => ElementClass.Empty()
                .Add( "has-[label]:mt-[calc(theme(fontSize.small)_+_12px)]", when: slot is nameof( _base ) )
                .Add( ElementClass.Empty()
                    .Add( "text-medium" )
                    .Add( "left-3" )
                    .Add( "group-data-[filled-focused=true]:-translate-y-[calc(100%_+_theme(fontSize.small)/2_+_24px)]" ), when: slot is nameof( _label ) ),

            _ => ElementClass.Empty()
        };
    }

    public static string GetStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _base )
            .Add( _disabled, when: textBox.Disabled )
            .Add( _fullWidth, when: textBox.FullWidth )
            .Add( GetLabelPlacementStyles( textBox.LabelPlacement, slot: nameof( _base ) ) )
            .Add( GetLabelPlacementOutsideBySizeStyles( textBox.Size, slot: nameof( _base ) ), when: textBox.LabelPlacement is LabelPlacement.Outside )
            .Add( textBox.Class )
            .Add( textBox.Classes?.Root )
            .ToString();
    }

    public static string GetLabelStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _label )
            .Add( GetVariantStyles( textBox.Variant, slot: nameof( _label ) ) )
            .Add( GetVariantFlatByColorStyles( textBox.Color, slot: nameof( _label ) ), when: textBox.Variant is InputVariant.Flat )
            .Add( GetVariantOutlinedByColorStyles( textBox.Color, slot: nameof( _label ) ), when: textBox.Variant is InputVariant.Outlined )
            .Add( GetVariantUnderlinedByColorStyles( textBox.Color, slot: nameof( _label ) ), when: textBox.Variant is InputVariant.Underlined )
            .Add( GetLabelPlacementStyles( textBox.LabelPlacement, slot: nameof( _label ) ) )
            .Add( GetLabelPlacementInsideBySizeStyles( textBox.Size, slot: nameof( _label ) ), when: textBox.LabelPlacement is LabelPlacement.Inside )
            .Add( GetLabelPlacementOutsideBySizeStyles( textBox.Size, slot: nameof( _label ) ), when: textBox.LabelPlacement is LabelPlacement.Outside )
            .Add( GetInvalidStyles( slot: nameof( _label ) ), when: textBox.Invalid )
            .Add( GetRequiredStyles( slot: nameof( _label ) ), when: textBox.Required )
            // LabelPlacement & ThemeColor.Default
            .Add( ElementClass.Empty()
                .Add( "group-data-[filled-focused=true]:text-default-600", when: textBox.LabelPlacement is LabelPlacement.Inside && textBox.Color is ThemeColor.Default )
                .Add( "group-data-[filled-focused=true]:text-foreground", when: textBox.LabelPlacement is LabelPlacement.Outside && textBox.Color is ThemeColor.Default ) )
            .Add( textBox.Classes?.Label )
            .ToString();
    }

    public static string GetMainWrapperStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _mainWrapper )
            .Add( GetLabelPlacementStyles( textBox.LabelPlacement, slot: nameof( _mainWrapper ) ) )
            .Add( textBox.Classes?.MainWrapper )
            .ToString();
    }

    public static string GetInputWrapperStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _inputWrapper )
            .Add( GetSizeStyles( textBox.Size, slot: nameof( _inputWrapper ) ) )
            .Add( GetRadiusStyles( textBox.Radius, slot: nameof( _inputWrapper ) ) )
            .Add( GetVariantStyles( textBox.Variant, slot: nameof( _inputWrapper ) ) )
            .Add( GetVariantInvalidStyles( textBox.Variant, slot: nameof( _inputWrapper ) ), when: textBox.Invalid )
            .Add( GetVariantFlatByColorStyles( textBox.Color, slot: nameof( _inputWrapper ) ), when: textBox.Variant is InputVariant.Flat )
            .Add( GetVariantOutlinedByColorStyles( textBox.Color, slot: nameof( _inputWrapper ) ), when: textBox.Variant is InputVariant.Outlined )
            .Add( GetVariantUnderlinedByColorStyles( textBox.Color, slot: nameof( _inputWrapper ) ), when: textBox.Variant is InputVariant.Underlined )
            .Add( GetLabelPlacementStyles( textBox.LabelPlacement, slot: nameof( _inputWrapper ) ) )
            .Add( GetLabelPlacementInsideBySizeStyles( textBox.Size, slot: nameof( _inputWrapper ) ), when: textBox.LabelPlacement is LabelPlacement.Inside )
            // Outlined & Size.Small
            .Add( "py-1", when: textBox.Variant is InputVariant.Outlined && textBox.Size is Size.Small )
            .Add( textBox.Classes?.InputWrapper )
            .ToString();
    }

    public static string GetInnerWrapperStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _innerWrapper )
            .Add( GetVariantStyles( textBox.Variant, slot: nameof( _innerWrapper ) ) )
            .Add( GetLabelPlacementStyles( textBox.LabelPlacement, slot: nameof( _innerWrapper ) ) )
            // Underlined & Size
            .Add( ElementClass.Empty()
                .Add( "pb-0.5", when: textBox.Variant is InputVariant.Underlined && textBox.Size is Size.Small )
                .Add( "pb-1.5", when: textBox.Variant is InputVariant.Underlined && ( textBox.Size is Size.Medium or Size.Large ) ) )
            .Add( textBox.Classes?.InnerWrapper )
            .ToString();
    }

    public static string GetInputStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _input )
            .Add( GetSizeStyles( textBox.Size, slot: nameof( _input ) ) )
            .Add( GetVariantFlatByColorStyles( textBox.Color, slot: nameof( _input ) ), when: textBox.Variant is InputVariant.Flat )
            .Add( GetVariantUnderlinedByColorStyles( textBox.Color, slot: nameof( _input ) ), when: textBox.Variant is InputVariant.Underlined )
            .Add( GetClearableStyles( slot: nameof( _input ) ) )
            .Add( GetInvalidStyles( slot: nameof( _input ) ), when: textBox.Invalid )
            .Add( textBox.Classes?.Input )
            .ToString();
    }

    public static string GetClearButtonStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _clearButton )
            .Add( GetSizeStyles( textBox.Size, slot: nameof( _clearButton ) ) )
            .Add( GetClearableStyles( slot: nameof( _clearButton ) ) )
            .Add( textBox.Classes?.ClearButton )
            .ToString();
    }

    public static string GetHelperWrapperStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _helperWrapper )
            .Add( textBox.Classes?.HelperWrapper )
            .ToString();
    }

    public static string GetDescriptionStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _description )
            .Add( textBox.Classes?.Description )
            .ToString();
    }

    public static string GetErrorMessageStyles( LumexTextBox textBox )
    {
        return ElementClass.Empty()
            .Add( _errorMessage )
            .Add( textBox.Classes?.ErrorMessage )
            .ToString();
    }
}