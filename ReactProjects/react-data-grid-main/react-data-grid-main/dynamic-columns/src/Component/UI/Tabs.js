import React, { useState, useMemo, useCallback } from 'react';
import MuiTabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Box from '@mui/material/Box';
import { Paper } from '@mui/material';

import DynamicColsGrid from '../../dynamicColsGrid';

const Tabs = () => {
  const [value, setValue] = useState('1');
  let content_array = useMemo(
    () => [<DynamicColsGrid />, <h2>Nothing</h2>, <h2>Nothing</h2>],
    []
  );

  const handleChange = useCallback((event, value) => {
    setValue(value);
  }, []);

  return (
    <Box sx={{ width: '100%' }}>
      <MuiTabs value={value} onChange={handleChange}>
        <Tab value='1' label='Item One' />
        <Tab value='2' label='Item Two' />
        <Tab value='3' label='Item Three' />
      </MuiTabs>
      <Paper style={{ width: '100%', height: 1000 }}>
        {content_array[+value - 1]}
      </Paper>
    </Box>
  );
};

export default React.memo(Tabs);
