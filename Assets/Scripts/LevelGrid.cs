using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{

    public static LevelGrid Instance { get; private set; }

    [SerializeField] private Transform gridDebugObjectPrefab;
    private GridSystem gridSystem;
    private Unit unit;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one Level Grid!! " + transform + "  -  " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnitList();
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = gridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public void UnitMoveGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition)
    {
        RemoveUnitAtGridPosition(fromGridPosition, unit);

        AddUnitAtGridPosition(toGridPosition, unit);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition); //=> replaces {}. if function returns something then it does so automatically and without a return function.
}
