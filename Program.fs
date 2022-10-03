open System

type Decision(id: Guid, description: string, note: string, child: Option<Decision>) =
    member this.Id = id
    member this.Description = description
    member this.Note = note
    member this.Child = child
    with
        override this.ToString() =
            let renderedNote =
                if String.IsNullOrWhiteSpace(this.Note) then
                    ""
                else
                    $"\nnote right of {this.Id:N}\n{this.Note}\nend note"

            match this.Child with
            | Some x ->
                $"state \"{this.Description}\" as {this.Id:N}\n{x.ToString()}\n{this.Id:N} --> {x.Id:N}{renderedNote}"
            | None -> $"state \"{this.Description}\" as {this.Id:N}\n{this.Id:N} --> [*]{renderedNote}"

let renderText (decision: Decision) : string =
    $"```mermaid\nstateDiagram-v2\n{decision.ToString()}\n[*] --> {decision.Id:N}\n```"

let decision =
    Decision(
        Guid.NewGuid(),
        "hello world!",
        "none!\nwer\nhtrh",
        Some(Decision(Guid.NewGuid(), "child 1", "none 1", Some(Decision(Guid.NewGuid(), "child 2", "none 2", None))))
    )

printfn $"{renderText decision}"