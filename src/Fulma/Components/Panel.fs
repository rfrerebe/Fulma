namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Panel =

    module Block =

        type Option =
            /// Add `is-active` class if true
            | [<CompiledName("is-active")>] IsActive of bool
            | Props of IHTMLProp list
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

    module Tab =

        type Option =
            /// Add `is-active` class if true
            | [<CompiledName("is-active")>] IsActive of bool
            | Props of IHTMLProp list
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

    /// Generate <div class="panel-block"></div>
    let block (options : Block.Option list) children =
        let parseOption (result: GenericOptions) opt =
            match opt with
            | Block.IsActive state -> if state then result.AddCaseName opt else result
            | Block.Props props -> result.AddProps props
            | Block.CustomClass customClass -> result.AddClass customClass
            | Block.Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "panel-block").ToReactElement(div, children)

    /// Generate <label class="panel-block"></label>
    let checkbox (options : Block.Option list) children =
        let parseOption (result: GenericOptions) opt =
            match opt with
            | Block.IsActive state -> if state then result.AddCaseName opt else result
            | Block.Props props -> result.AddProps props
            | Block.CustomClass customClass -> result.AddClass customClass
            | Block.Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "panel-block").ToReactElement(label, children)

    /// Generate <nav class="panel"></nav>
    let panel (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "panel").ToReactElement(nav, children)

    /// Generate <div class="panel-heading"></div>
    let heading (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "panel-heading").ToReactElement(div, children)

    /// Generate <div class="panel-tabs"></div>
    let tabs (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "panel-tabs").ToReactElement(div, children)

    /// Generate <a></a>
    let tab (options: Tab.Option list) children =
        let parseOption (result: GenericOptions) opt =
            match opt with
            | Tab.IsActive state -> if state then result.AddCaseName opt else result
            | Tab.Props props -> result.AddProps props
            | Tab.CustomClass customClass -> result.AddClass customClass
            | Tab.Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption).ToReactElement(a, children)

    /// Generate <span class="panel-icon"></span>
    let icon (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "panel-icon").ToReactElement(span, children)
