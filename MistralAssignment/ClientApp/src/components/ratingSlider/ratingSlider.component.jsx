import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography';
import Slider from '@material-ui/core/Slider';

const useStyles = makeStyles({
  root: {
    width: 150,
  },
});

export default function RatingSlider(props) {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Typography gutterBottom>
        {props.name}
      </Typography>
      <Slider
        defaultValue={props.defaultValue}
        valueLabelDisplay="auto"
        step={props.step}
        key={JSON.stringify(props)}
        marks
        min={1}
        max={5}
        onChangeCommitted={props.onChangeCommitted}
        disabled={props.disabled}
      />
    </div>
  );
}