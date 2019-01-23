namespace Fulma

open Fable.Import.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
type Screen =
    | All
    | [<CompiledName("desktop")>] Desktop
    | [<CompiledName("tablet")>] Tablet
    | [<CompiledName("mobile")>] Mobile
    | [<CompiledName("widescreen")>] WideScreen
    | [<CompiledName("touch")>] Touch
    | [<CompiledName("fullhd")>] FullHD

    static member toString opt =
        match opt with
        | All -> ""
        | Desktop
        | Tablet
        | Mobile
        | WideScreen
        | Touch
        | FullHD -> "-" + Fable.Core.Reflection.getCaseName opt

[<AutoOpen>]
module Color =

    type IColor =
        | [<CompiledName("is-black")>] IsBlack
        | [<CompiledName("is-dark")>] IsDark
        | [<CompiledName("is-light")>] IsLight
        | [<CompiledName("is-white")>] IsWhite
        | [<CompiledName("is-primary")>] IsPrimary
        | [<CompiledName("is-info")>] IsInfo
        | [<CompiledName("is-success")>] IsSuccess
        | [<CompiledName("is-warning")>] IsWarning
        | [<CompiledName("is-danger")>] IsDanger
        | [<CompiledName("is-link")>] IsLink
        | [<CompiledName("is-black-bis")>] IsBlackBis
        | [<CompiledName("is-black-ter")>] IsBlackTer
        | [<CompiledName("is-grey-darker")>] IsGreyDarker
        | [<CompiledName("is-grey-dark")>] IsGreyDark
        | [<CompiledName("is-grey")>] IsGrey
        | [<CompiledName("is-grey-light")>] IsGreyLight
        | [<CompiledName("is-grey-lighter")>] IsGreyLighter
        | [<CompiledName("is-white-ter")>] IsWhiteTer
        | [<CompiledName("is-white-bis")>] IsWhiteBis
        /// Allow you to specify a custom color. The color will be prefixed by "is-"
        | IsCustomColor of string
        /// Allow you to specify a NoColor case.
        | NoColor

    let ofColor level =
        match level with
        | NoColor -> ""
        | IsCustomColor color -> "is-" + color
        | IsBlack
        | IsDark
        | IsLight
        | IsWhite
        | IsPrimary
        | IsInfo
        | IsSuccess
        | IsWarning
        | IsDanger
        | IsLink
        | IsBlackBis
        | IsBlackTer
        | IsGreyDarker
        | IsGreyDark
        | IsGrey
        | IsGreyLight
        | IsGreyLighter
        | IsWhiteTer
        | IsWhiteBis -> Fable.Core.Reflection.getCaseName level

[<AutoOpen>]
module Size =

    type ISize =
        | [<CompiledName("is-small")>] IsSmall
        | [<CompiledName("is-medium")>] IsMedium
        | [<CompiledName("is-large")>] IsLarge

    let inline ofSize size =
        Fable.Core.Reflection.getCaseName size

[<RequireQualifiedAccess>]
module TextSize =
    type Option =
        | Is1
        | Is2
        | Is3
        | Is4
        | Is5
        | Is6
        | Is7

        static member toString (x: Option) =
            Fable.Core.Reflection.getCaseTag x + 1 |> string

    let inline generic screen size =
        "is-size-" + Option.toString size + Screen.toString screen

    let inline only screen size =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            "is-size-" + Option.toString size + Screen.toString screen + "-only"
        | x ->
            Fable.Import.JS.console.warn("Screen `%s` does not support `is-size-xxx-only`." + string x)
            ""

[<RequireQualifiedAccess>]
module TextAlignment =

    type Option =
        /// Add `has-text-centered`
        | [<CompiledName("has-text-centered")>] Centered
        /// Add `has-text-justified`
        | [<CompiledName("has-text-justified")>] Justified
        /// Add `has-text-left`
        | [<CompiledName("has-text-left")>] Left
        /// Add `has-text-right`
        | [<CompiledName("has-text-left")>] Right

        static member inline toString opt =
            Fable.Core.Reflection.getCaseName opt

    let inline generic screen alignment =
        Option.toString alignment + Screen.toString screen

    let inline only screen alignment =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            Option.toString alignment + Screen.toString screen + "-only"
        | x ->
            Fable.Import.JS.console.warn("Screen `%s` does not support `is-size-xxx-only`." + string x)
            ""

[<RequireQualifiedAccess>]
module TextWeight =

    type Option =
        /// Add `has-text-weight-light`
        | [<CompiledName("has-text-weight-light")>] Light
        /// Add `has-text-weight-normal`
        | [<CompiledName("has-text-weight-normal")>] Normal
        /// Add `has-text-weight-semi-bold`
        | [<CompiledName("has-text-weight-semi-bold")>] SemiBold
        /// Add `has-text-weight-bold`
        | [<CompiledName("has-text-weight-bold")>] Bold

    let inline internal ofOption opt =
        Fable.Core.Reflection.getCaseName opt

[<RequireQualifiedAccess>]
module TextTransform =

    type Option =
        /// Add `is-capitalized`
        | [<CompiledName("is-capitalized")>] Capitalized
        /// Add `is-lowercase`
        | [<CompiledName("is-lowercase")>] LowerCase
        /// Add `is-uppercase`
        | [<CompiledName("is-uppercase")>] UpperCase
        /// Add `is-italic`
        | [<CompiledName("is-italic")>] Italic

        static member inline toClass opt =
            Fable.Core.Reflection.getCaseName opt

[<RequireQualifiedAccess>]
module Display =

    type Option =
        | [<CompiledName("block")>] Block
        | [<CompiledName("flex")>] Flex
        | [<CompiledName("inline")>] Inline
        | [<CompiledName("inline-block")>] InlineBlock
        | [<CompiledName("inline-flex")>] InlineFlex

        static member inline toClass opt =
            Fable.Core.Reflection.getCaseName opt

    let internal toDisplayClass screen display =
        let display = Option.toClass display
        let screen = Screen.toString screen

        "is-" + display + screen

    let internal toDisplayOnlyClass screen display =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            let display = Option.toClass display
            let screen = Screen.toString screen
            "is-" + display + screen + "-only"

        | x ->
            Fable.Import.JS.console.warn("Screen `%s` does not support display only." + string x)
            ""

[<RequireQualifiedAccess>]
module Modifier =
    let internal ofBackground level =
        match level with
        | NoColor -> ""
        | IsCustomColor color -> "has-background-" + color
        | IsBlack
        | IsDark
        | IsLight
        | IsWhite
        | IsPrimary
        | IsInfo
        | IsSuccess
        | IsWarning
        | IsDanger
        | IsLink
        | IsBlackBis
        | IsBlackTer
        | IsGreyDarker
        | IsGreyDark
        | IsGrey
        | IsGreyLight
        | IsGreyLighter
        | IsWhiteTer
        | IsWhiteBis -> "has-background-" + (Fable.Core.Reflection.getCaseName level).[3..]

    let internal ofText level =
        match level with
        | NoColor -> ""
        | IsCustomColor color -> "has-text-" + color
        | IsBlack
        | IsDark
        | IsLight
        | IsWhite
        | IsPrimary
        | IsInfo
        | IsSuccess
        | IsWarning
        | IsDanger
        | IsLink
        | IsBlackBis
        | IsBlackTer
        | IsGreyDarker
        | IsGreyDark
        | IsGrey
        | IsGreyLight
        | IsGreyLighter
        | IsWhiteTer
        | IsWhiteBis -> "has-text-" + (Fable.Core.Reflection.getCaseName level).[3..]

    let internal ofInvisible screen =
        "is-invisible" + Screen.toString screen

    let internal ofHidden screen =
        "is-hidden" + Screen.toString screen

    let internal ofInvisibleOnly screen =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            "is-invisible" + Screen.toString screen + "-only"
        | x ->
            Fable.Import.JS.console.warn("Screen `%s` does not support `is-invisible-xxx-only`." + string x)
            ""

    let internal ofHiddenOnly screen =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            "is-hidden" + Screen.toString screen + "-only"
        | x ->
            Fable.Import.JS.console.warn("Screen `%s` does not support `is-hidden-xxx-only`." + string x)
            ""

    type IModifier =
        | BackgroundColor of IColor
        | TextColor of IColor
        | TextWeight of TextWeight.Option
        | TextSize of Screen * TextSize.Option
        | TextSizeOnly of Screen * TextSize.Option
        | TextAlignment of Screen * TextAlignment.Option
        | TextAlignmentOnly of Screen * TextAlignment.Option
        | TextTransform of TextTransform.Option
        | Display of Screen * Display.Option
        | DisplayOnly of Screen * Display.Option
        | [<CompiledName("is-clearfix")>] IsClearfix
        | [<CompiledName("is-pulled-left")>] IsPulledLeft
        | [<CompiledName("is-pulled-right")>] IsPulledRight
        | [<CompiledName("is-marginless")>] IsMarginless
        | [<CompiledName("is-paddingless")>] IsPaddingless
        | [<CompiledName("is-overlay")>] IsOverlay
        | [<CompiledName("is-clipped")>] IsClipped
        | [<CompiledName("is-radiusless")>] IsRadiusless
        | [<CompiledName("is-shadowless")>] IsShadowless
        | [<CompiledName("is-unselectable")>] IsUnselectable
        | IsInvisible of Screen * bool
        | IsHidden of Screen * bool
        | IsInvisibleOnly of Screen * bool
        | IsHiddenOnly of Screen * bool
        | IsSrOnly
        | IsScreenReaderOnly

    let parseModifiers options =
        let parseOption result opt =
            match opt with
            | BackgroundColor color             -> (ofBackground color)::result
            | TextColor color                   -> (ofText color)::result
            | TextWeight textWeight             -> (TextWeight.ofOption textWeight)::result
            | TextSize (screen, size)           -> (TextSize.generic screen size)::result
            | TextSizeOnly (screen, size)       -> (TextSize.only screen size)::result
            | TextAlignment (screen, size)      -> (TextAlignment.generic screen size)::result
            | TextAlignmentOnly (screen, size)  -> (TextAlignment.only screen size)::result
            | TextTransform transform           -> (TextTransform.Option.toClass transform)::result
            | Display (screen, display)         -> (Display.toDisplayClass screen display)::result
            | DisplayOnly (screen, display)     -> (Display.toDisplayOnlyClass screen display)::result
            | IsInvisible (screen, b)           -> if b then (ofInvisible screen)::result else result
            | IsInvisibleOnly (screen, b)       -> if b then (ofInvisibleOnly screen)::result else result
            | IsHidden (screen, b)              -> if b then (ofHidden screen)::result else result
            | IsHiddenOnly (screen, b)          -> if b then (ofHiddenOnly screen)::result else result
            | IsSrOnly
            | IsScreenReaderOnly -> "is-sr-only"::result
            | IsClearfix
            | IsPulledLeft
            | IsPulledRight
            | IsMarginless
            | IsPaddingless
            | IsOverlay
            | IsClipped
            | IsRadiusless
            | IsShadowless
            | IsUnselectable -> (Fable.Core.Reflection.getCaseName opt)::result

        options |> List.fold parseOption []

[<AutoOpen>]
module Common =
    type GenericOption =
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    type GenericOptions =
        { Props : IHTMLProp list
          Classes : string list }

        static member Empty =
            { Props = []; Classes = [] }

        static member Parse(options, parser, ?baseClass) =
            let result = options |> List.fold parser GenericOptions.Empty
            match baseClass with
            | Some baseClass -> result.AddClass(baseClass)
            | None -> result

        member this.AddProp(prop) =
            { this with Props = prop::this.Props }

        member this.AddProps(props) =
            { this with Props = props@this.Props }

        member this.AddClass(cl: string) =
            { this with Classes = cl::this.Classes }

        member this.AddCaseName(case: obj) =
            Fable.Core.Reflection.getCaseName case |> this.AddClass

        member this.AddModifiers(modifiers) =
            { this with Classes = (modifiers |> Modifier.parseModifiers) @ this.Classes }

        /// Conver to standard element
        member this.ToReactElement(el : IHTMLProp list -> ReactElement list -> ReactElement, ?children): ReactElement =
            let children = defaultArg children []
            // TODO: Remove empty classes?
            let classes = String.concat " " this.Classes |> ClassName :> IHTMLProp
            el (classes::this.Props) children

        /// Convert to self closing element
        member this.ToReactElement(el : IHTMLProp list -> ReactElement): ReactElement =
            // TODO: Remove empty classes?
            let classes = String.concat " " this.Classes |> ClassName :> IHTMLProp
            el (classes::this.Props)

    let parseOption (result: GenericOptions ) = function
        | Props props -> result.AddProps props
        | CustomClass customClass -> result.AddClass customClass
        | Modifiers modifiers -> result.AddModifiers modifiers

    module Helpers =

        let classes std (options : string option list) (booleans: (string * bool) list) =
            let std = (std, options) ||> List.fold (fun complete opt ->
                match opt with Some name -> complete + " " + name | None -> complete)
            (std, booleans) ||> List.fold (fun complete (name, flag) ->
                if flag then complete + " " + name else complete)
            |> ClassName :> IHTMLProp

[<RequireQualifiedAccess>]
module Text =
    open Fable.Helpers.React

    let p (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption).ToReactElement(p, children)

    let div (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption).ToReactElement(div, children)

    let span (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption).ToReactElement(span, children)
