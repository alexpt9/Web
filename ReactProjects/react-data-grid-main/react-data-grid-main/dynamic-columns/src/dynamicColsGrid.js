import React, { useState } from 'react';
import { AgGridReact } from 'ag-grid-react';

import 'ag-grid-enterprise';

import 'ag-grid-community/dist/styles/ag-grid.css';
import 'ag-grid-community/dist/styles/ag-theme-alpine-dark.css';

const sideBar = {
  toolPanels: [
    {
      id: 'columns',
      labelDefault: 'Columns',
      labelKey: 'columns',
      iconKey: 'columns',
      toolPanel: 'agColumnsToolPanel',
      minWidth: 225,
      maxWidth: 225,
      width: 225,
    },
    {
      id: 'filters',
      labelDefault: 'Filters',
      labelKey: 'filters',
      iconKey: 'filter',
      toolPanel: 'agFiltersToolPanel',
      minWidth: 180,
      maxWidth: 400,
      width: 250,
    },
  ],
  position: 'right',
};

const DynamicColsGrid = () => {
  // set to default data
  const [rowData, setRowData] = useState();
  const [colDefs, setColDefs] = useState([]);

  const url = 'https://swapi.dev/api/people/';

  // swapi.dev requires a little extra processing to process the response since it needs a content type header
  // and the json is an object but we are only interested in the results array in the object.
  React.useEffect(() => {
    fetch(url, {
      method: 'GET',
      headers: { 'Content-Type': 'application/json' },
    })
      .then((result) => result.json())
      .then((data) => {
        const keys = Object.keys(data.results[0]);
        let jsonColDefs = keys.map((key) => {
          return {
            field: key,
            resizable: true,
            filter: 'agTextColumnFilter',
            floatingFilter: true,
            enableRowGroup: true,
            enablePivot: true,
          };
        });
        setColDefs(jsonColDefs);
        setRowData(data.results);
      });
  }, []);

  return (
    <AgGridReact
      className='ag-theme-alpine-dark'
      style={{ width: '100%', height: 1000 }}
      defaultColDef={{ sortable: true, filter: true }}
      enableRowGroup={true}
      rowGroupPanelShow={'onlyWhenGrouping'}
      pagination={true}
      rowData={rowData}
      columnDefs={colDefs}
      sideBar={sideBar}
    />
  );
};

export default React.memo(DynamicColsGrid);
