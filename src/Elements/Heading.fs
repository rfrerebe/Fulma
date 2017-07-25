namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Heading =
    module Types =
        type ITitleSize =
            | Is1
            | Is2
            | Is3
            | Is4
            | Is5
            | Is6

        let ofTitleSize titleSize =
            match titleSize with
            | Is1 -> Bulma.Heading.Size.Is1
            | Is2 -> Bulma.Heading.Size.Is2
            | Is3 -> Bulma.Heading.Size.Is3
            | Is4 -> Bulma.Heading.Size.Is4
            | Is5 -> Bulma.Heading.Size.Is5
            | Is6 -> Bulma.Heading.Size.Is6

        type Option =
            | Size of ITitleSize
            | IsSubtitle
            | IsSpaced
            | CustomClass of string
            | Props of IHTMLProp list

        type Options =
            { TitleSize : string option
              TitleType : string
              IsSpaced : bool
              CustomClass : string option
              Props : IHTMLProp list }
            static member Empty =
                { TitleSize = None
                  TitleType = Bulma.Heading.Title
                  IsSpaced = false
                  CustomClass = None
                  Props = [] }

    open Types

    //Types
    let isSubtitle = IsSubtitle
    // Sizes
    let is1 = Size Is1
    let is2 = Size Is2
    let is3 = Size Is3
    let is4 = Size Is4
    let is5 = Size Is5
    let is6 = Size Is6
    // Spacing
    let isSpaced = IsSpaced
    // Extra
    let props = Props
    let customClass = CustomClass

    let internal title (element : IHTMLProp list -> React.ReactElement list -> React.ReactElement) (options : Option list)
        (children) =
        let parseOption result opt =
            match opt with
            | Size ts -> { result with TitleSize = ofTitleSize ts |> Some }
            | IsSubtitle -> { result with TitleType = Bulma.Heading.Subtitle }
            | IsSpaced -> { result with IsSpaced = true }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOption Options.Empty
        let className =
            classBaseList (Helpers.generateClassName opts.TitleType [ opts.TitleSize; opts.CustomClass ])
                [ Bulma.Heading.Spacing.IsNormal, opts.IsSpaced ]
        element
            [ yield className :> IHTMLProp
              yield! opts.Props ]
            children

    // Alias
    let h1 (options : Option list) = title h1 (is1 :: options)
    let h2 (options : Option list) = title h2 (is2 :: options)
    let h3 (options : Option list) = title h3 (is3 :: options)
    let h4 (options : Option list) = title h4 (is4 :: options)
    let h5 (options : Option list) = title h5 (is5 :: options)
    let h6 (options : Option list) = title h6 (is6 :: options)
    let p = title p
