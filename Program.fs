open System
open System.Text.Json

type Decision(id: Guid, description: string, note: string, child: option<seq<Decision>>) =
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
                Seq.fold
                    (fun accelerator (y: Decision) ->
                        accelerator
                        + $"{y.ToString()}\n{this.Id:N} --> {y.Id:N}\n")
                    $"state \"{this.Description}\" as {this.Id:N}\n{renderedNote}\n"
                    x
            | None -> $"state \"{this.Description}\" as {this.Id:N}\n{this.Id:N} --> [*]{renderedNote}\n"

let renderText (decision: Decision) : string =
    $"```mermaid\nstateDiagram-v2\n{decision.ToString()}\n[*] --> {decision.Id:N}```"

let decision =
    Decision(
        Guid.NewGuid(),
        "hello world!",
        "note!\nline 2\n\tformatted line 3",
        Some(
            seq {
                Decision(
                    Guid.NewGuid(),
                    "child 1",
                    "note 1",
                    Some(
                        seq {
                            Decision(Guid.NewGuid(), "child 2", "note 2", None)
                            Decision(Guid.NewGuid(), "child 3", "note 3", None)
                        }
                    )
                )
            }
        )
    )

let serializedDecision = JsonSerializer.Serialize decision

let deserializedDecision = JsonSerializer.Deserialize<Decision> serializedDecision

printfn $"{serializedDecision}"

printfn $"{renderText deserializedDecision}"