import * as React from 'react';
import CssBaseline from '@mui/material/CssBaseline';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import Link from '@mui/material/Link';

const HomeGrid = () => {
    return (
        <Box
          sx={{
            display: 'flex',
            flexDirection: 'column',
            minHeight: '100vh',
          }}
        >
          <CssBaseline />
          <Container component="main" sx={{ mt: 8, mb: 2 }} maxWidth="sm">
            <Typography variant="h2" component="h1" gutterBottom>
              Home
            </Typography>
            <Typography variant="h5" component="h2" gutterBottom>
              {'WebStore Web App'}
              {'CRUD Operations.'}
            </Typography>
            <Typography variant="body1">Home Component.</Typography>
          </Container>
        </Box>
      );
}

export default HomeGrid