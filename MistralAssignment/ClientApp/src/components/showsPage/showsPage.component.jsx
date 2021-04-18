import React, { useEffect, useState } from 'react';

import API from '../../api';

import { Button, FormControl, IconButton, Input, InputAdornment, InputLabel, Typography } from '@material-ui/core';
import SearchIcon from '@material-ui/icons/Search';
import ShowList from '../showList/showList.component';

const ShowsPage = (props) => {

    const [searchString, setSearchString] = useState("");
    const [resultsCount, setResultsCount] = useState(0);
    const [loadMoreHidden, setLoadMoreHidden] = useState(true);

    const handleSearchStringChange = (event) => {

      const searchString = event.target.value;
      setSearchString(searchString);

      const trimmedString = searchString.trim();
      if(trimmedString.length > 1) {
        getShows(trimmedString)
      } else if(trimmedString.length == 0) {
          getShows();
      }
    }

    const [showsList, setShowsList] = useState([]);

    useEffect(() => {
        getShows();
    }, []);

    const getShows = async (searchString) => {
        const searchArgs = { 
            ShowTypeId: props.type === "moviePage" ? 1 : 2,
        }

        if(searchString) searchArgs.SearchString = searchString;
        const response = await API.get('Show', {params: searchArgs});

        setShowsList(response.data);

        const numberOfResults = response.data.length;
        setResultsCount(0+numberOfResults);

        numberOfResults == 10 ? setLoadMoreHidden(false) : setLoadMoreHidden(true);
    }

    const loadMoreResults = async () => {
        const searchArgs = { 
            ShowTypeId: props.type === "moviePage" ? 1 : 2,
            Skip: resultsCount
        }

        if(searchString) searchArgs.SearchString = searchString;
        const response = await API.get('Show', {params: searchArgs});

        const numberOfResults = response.data.length;

        setShowsList([...showsList].concat(response.data));
        setResultsCount(resultsCount + response.data.length);

        numberOfResults == 10 ? setLoadMoreHidden(false) : setLoadMoreHidden(true);
    }

    return (
        <div>
            <FormControl>
                <InputLabel>Search</InputLabel>
                <Input
                    className="search-input"
                    type={'text'}
                    value={searchString}
                    onChange={handleSearchStringChange}
                    endAdornment={
                        <InputAdornment position="end">
                        <IconButton>
                            <SearchIcon />
                        </IconButton>
                        </InputAdornment>
                    }
                />
            </FormControl>

            <ShowList
             shows={showsList}
            />
            {!loadMoreHidden ?
                <Button color="primary" variant="contained" hidden={loadMoreHidden} onClick={loadMoreResults}>
                    Load more results
                </Button>
            : 
                <Typography>No more results. Search for something else?</Typography>
            }
        </div>
    )
}

export default ShowsPage;