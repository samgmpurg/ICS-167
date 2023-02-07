using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGroupable
{
    Player Owner { get; set; }

    bool IsComposite();

    void AddToGroup(List<IGroupable> toAdd);

    void RemoveFromGroup(List<IGroupable> toRemove);

    void RemoveAndDestroy(List<IGroupable> toRemove);
}
